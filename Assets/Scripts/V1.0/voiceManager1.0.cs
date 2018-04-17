using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows.Speech;
using System.Linq;
using UnityEngine.UI;
using System.Text;
using TaskManager;


public class voiceManager1 : MonoBehaviour {
	// define data that can be requested
	static string[] keys = new string[20] {"EVA Time","O2 Off Toggle","SOP Toggle","Battery Capacity","Fan Failure Toggle","Fan Tachometer","H20 Gas Pressure","Internal Suit Pressure",
		"No Vent Flow Toggle","Oxygen Pressure","Oxygen Rate","SOP Pressure","SOP Rate","Spacesuit Presser Emergency Toggle","Sub Pressure",
		"Sub Temperature","Time Life Battery","Time Life Oxygen","Time Life Water","Vehicle Power Present"}; 
	// preallocate key word recongizer
	KeywordRecognizer keywordRecognizer;
	Dictionary<string, System.Action> keywords = new Dictionary<string, System.Action>();
	taskManager task = new taskManager();

	// Initialize
	void Start(){
		task.initializeTask ();
		// hide additional info
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Time").GetComponent<Canvas>().enabled = false;
		//Initialize keywords and actions for keyword recognizer (add keywords and events)
		keywords.Add("Open Suit", () => // open overlays
			{
				openOverlay(1);
			});
		keywords.Add("Open Time", () =>
			{
				openOverlay(2);
			});
		keywords.Add("Open Pad", () =>
			{
				openOverlay(3);
			});
		keywords.Add("Open Task", () =>
			{
				openOverlay(4);
			});
		keywords.Add("Open All", () =>
			{
				allOn();
			});
		keywords.Add("Clear Suit", () => // clear overlays
			{
				clearOverlay(1);
			});
		keywords.Add("Clear Time", () =>
			{
				clearOverlay(2);
			});
		keywords.Add("Clear Pad", () =>
			{
				clearOverlay(3);
			});
		keywords.Add("Clear Task", () =>
			{
				clearOverlay(4);
			});
		keywords.Add ("Clear All", () =>
			{
				alloff();
			});
		keywords.Add ("Show Sub", () => // sub-menu selected
			{
				subMenuSelected(1);
			});
		keywords.Add ("Show Internal", () => 
			{
				subMenuSelected(2);
			});
		keywords.Add ("Show Misc", () => 
			{
				subMenuSelected(3);
			});
		keywords.Add ("Show SOP", () => 
			{
				subMenuSelected(4);
			});
		keywords.Add ("Hide Submenu", () => // sub-menu hide
			{
				subMenuRestore();
			});
		keywords.Add ("Next Step", () => // sub-menu hide
			{
				task.NextStep();
			});
		keywords.Add ("Previous Step", () => // sub-menu hide
			{
				task.PrevioustStep();
			});
		keywords.Add ("Show Time", () => // control time menu
			{
				GameObject.Find("Submenu - Time").GetComponent<Canvas>().enabled = true;
			});
		keywords.Add ("Hide Time", () => // control time menu
			{
				GameObject.Find("Submenu - Time").GetComponent<Canvas>().enabled = false;
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

// ---------------------------------------------------------------------
// ------------------------ FUNCTION DEFINITIONS------------------------
// ---------------------------------------------------------------------
	// sub menu functions
	private void subMenuSelected(int subNum){
		// collect and toggle text objects
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = false;

		// update text of sub menu based on subNum
		if(subNum == 1){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if(subNum == 2){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if(subNum == 3){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = true;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if(subNum == 4){
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = true;
		}

	}
	private void subMenuRestore(){
		// collect and toggle text objects
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
	}
	// open an overlay
	private void openOverlay(int dispNum){
		if(dispNum == 1){
			Canvas selected = GameObject.Find ("Overlay - Info").GetComponent<Canvas> ();
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
			selected.enabled = true;
		}
		if(dispNum == 2){
			Canvas selected = GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ();
			selected.enabled = true;
		}
		if(dispNum == 3){
			Canvas selected = GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ();
			selected.enabled = true;
		}
		if(dispNum == 4){
			Canvas selected = GameObject.Find ("Overlay - Task").GetComponent<Canvas> ();
			selected.enabled = true;
		}
	}
	// clear an overlay
	private void clearOverlay(int dispNum){
		if(dispNum == 1){
			GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
			GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		}
		if (dispNum == 2) {
			Canvas selected = GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ();
			selected.enabled = false;
		}
		if(dispNum == 3){
			Canvas selected = GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ();
			selected.enabled = false;
		}
		if(dispNum == 4){
			Canvas selected = GameObject.Find ("Overlay - Task").GetComponent<Canvas> ();
			selected.enabled = false;
		}
	}
	// open all overlays
	private void allOn(){
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ().enabled = true;
		GameObject.Find ("Overlay - Task").GetComponent<Canvas> ().enabled = true;

	}
	// clear all overlays
	private void alloff(){
		GameObject.Find ("Overlay - Info").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Clock").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Pad").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Overlay - Task").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sub").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Int").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Misc").GetComponent<Canvas> ().enabled = false;
		GameObject.Find ("Submenu - Sop").GetComponent<Canvas> ().enabled = false;
	}


}

