using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
using System.Text;
using System;
using System.IO;
using System.Net;
//------------------
using Telemetry;
using TaskManager;
using VoiceCommands;
	
// ----------------------------
// define voice voice inputs and trigger functions
// ----------------------------
// DOESNT UPDATE PUSHED TEXT UNTIL AFTER ITS SUBMENU IS OPENED!!!!!!!!!!!!!

public class voiceManager: MonoBehaviour {
	// define keys
	static string[] keys = new string[19] {"O2 Off Toggle","SOP Toggle","Battery Capacity","Fan Failure Toggle","Fan Tachometer","H20 Gas Pressure","Internal Suit Pressure",
		"No Vent Flow Toggle","Oxygen Pressure","Oxygen Rate","SOP Pressure","SOP Rate","Spacesuit Pressure Emergency Toggle","Sub Pressure",
		"Sub Temperature","Time Life Battery","Time Life Oxygen","Time Life Water","Vehicle Power Present"}; 
	public string selectedSubMenu = "Submenu - Sub";

	// define telemetry manager
	public telemetryManager dataStream = new telemetryManager();
	public string current;
	// define voice commands
	public voiceCommands Commands = new voiceCommands();
	// hold information for scratch pad
	public string selected = ""; 
	// preallocate key word recongizer
	KeywordRecognizer keywordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	taskManager task = new taskManager();

	// preallocate timer
	public string[] timeLimits = new string[3];
	public DateTime startTime;
	public DateTime currentTime;
	public TimeSpan elapsed;
	public int tempMax;
	public int tempMin;
	public int[] order = new int[3];
	public string[] timeNames = new string[3];

	// Initialize: data stream, voice commands
	void Start(){
		// start timer
		timeNames [0] = "Time Life Battery";
		timeNames [1] = "Time Life Oxygen";
		timeNames [2] = "Time Life Water";
		startTime = DateTime.Now;
		GameObject.Find ("EVA Clock").GetComponent<Text> ().text = "00:00:00";
		// initialize data stream and task manager
		dataStream.onStart ();	
		task.initializeTask ();
		// hide additional info (submenus)
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Time").GetComponent<Canvas>().enabled = false;
		//Initialize keywords and actions for keyword recognizer (add keywords and events)
		keywords.Add("Open Suit", () => // open overlays
			{
				Commands.openOverlay(1);
			});
		keywords.Add("Open Time", () =>
			{
				Commands.openOverlay(2);
			});
		keywords.Add("Open Pad", () =>
			{
				Commands.openOverlay(3);
			});
		keywords.Add("Open Task", () =>
			{
				Commands.openOverlay(4);
			});
		keywords.Add("Open All", () =>
			{
				Commands.allOn();
			});
		keywords.Add("Clear Suit", () => // clear overlays
			{
				Commands.clearOverlay(1);
			});
		keywords.Add("Clear Time", () =>
			{
				Commands.clearOverlay(2);
			});
		keywords.Add("Clear Pad", () =>
			{
				Commands.clearOverlay(3);
			});
		keywords.Add("Clear Task", () =>
			{
				Commands.clearOverlay(4);
			});
		keywords.Add ("Clear All", () =>
			{
				Commands.alloff();
			});
		keywords.Add ("Show Sub", () => // sub-menu selected
			{
				Commands.subMenuSelected(1);
				selectedSubMenu = "Submenu - Sub";
			});
		keywords.Add ("Show Internal", () => 
			{
				Commands.subMenuSelected(2);
				selectedSubMenu = "Submenu - Int";
			});
		keywords.Add ("Show Misc", () => 
			{
				Commands.subMenuSelected(3);
				selectedSubMenu = "Submenu - Misc";
			});
		keywords.Add ("Show SOP", () => 
			{
				Commands.subMenuSelected(4);
				selectedSubMenu = "Submenu - Sop";
			});
		keywords.Add ("Show Time", () => // show time submenu
			{
				GameObject.Find("Submenu - Time").GetComponent<Canvas>().enabled = true;
			});
		keywords.Add ("Hide Time", () => // hide time submenu
			{
				GameObject.Find("Submenu - Time").GetComponent<Canvas>().enabled = false;
			});
		keywords.Add ("Submenu Back", () => // sub-menu hide
			{
				Commands.subMenuRestore();
			});
		keywords.Add ("Next Step", () => // navigate task
			{
				task.NextStep();
			});
		keywords.Add ("Previous Step", () => 
			{
				task.PrevioustStep();
			});
		foreach(string info in keys)
		{
			keywords.Add ("Push" + info, () => // Push information to scratch pad
				{
					selected = info;
				});
		}
		keywords.Add ("Errase Pad", () => // clear scratch pad
			{
				selected = "";
			});
			
		keywordRecognizer = new KeywordRecognizer(keywords.Keys.ToArray());
		keywordRecognizer.OnPhraseRecognized += KeywordRecognizer_OnPhraseRecognized;
		keywordRecognizer.Start();
	}

	// invoke action when input is recognized
	private void KeywordRecognizer_OnPhraseRecognized(PhraseRecognizedEventArgs args)
	{
		System.Action keywordAction;
		// if the keyword recognized is in our dictionary, call that Action.
		if (keywords.TryGetValue(args.text, out keywordAction))
		{
			keywordAction.Invoke();
		}
	}

	// Update: scratch pad text objects, time 
	void Update(){
		// update eva timer
		currentTime = DateTime.Now;
		elapsed = currentTime.Subtract (startTime);
		GameObject.Find ("EVA Clock").GetComponent<Text> ().text = elapsed.ToString ();

		// update scratch pad
		if (selected != "") {
			GameObject.Find ("Pad").GetComponent<Text> ().text = selected + ": " + dataStream.dataRequest(selected)["value"] + ": " + dataStream.dataRequest(selected)["status"];
		} else {
			GameObject.Find ("Pad").GetComponent<Text> ().text = "";
		}

		// watch dog
		dataStream.watchDog();

		// update submneu objects
		dataStream.updateSub (selectedSubMenu);


		// UPDATE TIME ---- DOESNT UPDATE UNTIL SUB MENUS ARE CALLED!!!!!
		// get text objects
		Text min = GameObject.Find ("time - short").GetComponent<Text> ();
		Text mid = GameObject.Find ("time - medium").GetComponent<Text> ();
		Text max = GameObject.Find ("time - long").GetComponent<Text> ();


		// update resource times
		timeLimits [0] = dataStream.dataRequest ("Time Life Battery") ["value"];
		timeLimits [1] = dataStream.dataRequest ("Time Life Oxygen") ["value"];
		timeLimits [2] = dataStream.dataRequest ("Time Life Water") ["value"];
		if(timeLimits[0] != "" && timeLimits[1] != "" && timeLimits[2] != "")
		{
			// compare first two
			if (Convert.ToDouble (timeLimits [0]) >= Convert.ToDouble (timeLimits [1])) {
				tempMax = 0;
				tempMin = 1;
			} else {
				tempMax = 1;
				tempMin = 0;
			}

			// compare third with other two
			if (Convert.ToDouble (timeLimits [2]) > Convert.ToDouble (timeLimits [tempMin]) && Convert.ToDouble (timeLimits [2]) < Convert.ToDouble (timeLimits [tempMax])) {
				order [0] = tempMin;
				order [1] = 2;
				order [2] = tempMax;
			} else {
				if (Convert.ToDouble (timeLimits [2]) > Convert.ToDouble (timeLimits [tempMax])) {
					order [0] = tempMin;
					order [1] = tempMax;
					order [2] = 2;
				} else {
					if (Convert.ToDouble (timeLimits [2]) < Convert.ToDouble (timeLimits [tempMin])) {
						order [0] = 2;
						order [1] = tempMin;
						order [2] = tempMax;
					}
				}
			}
		}
		min.text = timeNames [order [0]] + ":" + timeLimits [order [0]];
		mid.text = timeNames [order [1]] + ":" + timeLimits [order [1]];
		max.text = timeNames [order [2]] + ":" + timeLimits [order [2]];
	}
		
}