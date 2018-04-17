using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using Network;
using WatchDog;

// update text and track data with watchdog script. 
/*
public class telemetryManager1	: MonoBehaviour {

	// define keys
	static string[] keys = new string[20] {"EVA Time","O2 Off Toggle","SOP Toggle","Battery Capacity","Fan Failure Toggle","Fan Tachometer","H20 Gas Pressure","Internal Suit Pressure",
		"No Vent Flow Toggle","Oxygen Pressure","Oxygen Rate","SOP Pressure","SOP Rate","Spacesuit Presser Emergency Toggle","Sub Pressure",
		"Sub Temperature","Time Life Battery","Time Life Oxygen","Time Life Water","Vehicle Power Present"}; 
		
	// set data limits
	public static Dictionary<string, watchDog> allData = new Dictionary<string, watchDog>()
	{
		{"EVA Time", new watchDog{min = 10, max = 10}},
		{"O2 Off Toggle", new watchDog{min = 10, max = 10}},
		{"SOP Toggle", new watchDog{min = 10, max = 10}},
		{"Battery Capacity", new watchDog{min = 10, max = 10}},
		{"Fan Failure Toggle", new watchDog{min = 10, max = 10}},
		{"Fan Tachometer", new watchDog{min = 10, max = 10}},
		{"H20 Gas Pressure", new watchDog{min = 10, max = 10}},
		{"Internal Suit Pressure", new watchDog{min = 10, max = 10}},
		{"No Vent Flow Toggle", new watchDog{min = 10, max = 10}},
		{"Oxygen Pressure", new watchDog{min = 10, max = 10,}},
		{"Oxygen Rate", new watchDog{min = 10, max = 10}},
		{"SOP Pressure", new watchDog{min = 10, max = 10}},
		{"SOP Rate", new watchDog{min = 10, max = 10}},
		{"Spacesuit Presser Emergency Toggle", new watchDog{min = 10, max = 10}},
		{"Sub Pressure", new watchDog{min = 10, max = 10}},
		{"Sub Temperature", new watchDog{min = 10, max = 10}},
		{"Time Life Battery", new watchDog{min = 10, max = 10}},
		{"Time Life Oxygen", new watchDog{min = 10, max = 10}},
		{"Time Life Water", new watchDog{min = 10, max = 10}},
		{"Vehicle Power Present", new watchDog{min = 10, max = 10}}
	};

	// connect to network
	NetworkConnect dataStream = new NetworkConnect("127.0.0.1", 5005);
	public Dictionary<string, string> telemetry = new Dictionary<string, string>();

	// Use this for initialization
	void Start ()
	{
		Debug.Log ("Connecting...");
		dataStream.onStart ();
		Debug.Log ("Connected");
	}

	// Update is called once per frame
	void Update()
	{
		// update data
		telemetry = dataStream.onUpdate ();

		foreach (string name in keys){
			// update data to be used
			allData [name].current = telemetry [name];
			// check current status of data against limits
			allData [name].state = allData[name].checkStatus(telemetry[name]);
			// get and update text object selected
			if(GameObject.Find(name) != null){
				Text selected = GameObject.Find (name).GetComponent<Text> ();
				selected.text = name + ": " + telemetry [name];
			}
			}
		}

	}
*/
	
