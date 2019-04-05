using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Text;
using Network;
using System;
// ------------------------------
// connect to network and enable updated data request
// ------------------------------

namespace Telemetry{
	
	public class telemetryManager{
		// declaration
		private string value_string; // telemetry info as string
		private double value; // telemetry info as double
		// Define Structure Keys
		static string[] keys = new string[18] {"Battery Capacity","Fan Tachometer","H20 Gas Pressure","Internal Suit Pressure","Oxygen Pressure",
			"Oxygen Rate","SOP Pressure","SOP Rate","Sub Pressure","Sub Temperature","Time Life Battery","Time Life Oxygen","Time Life Water",
			"O2 Off Toggle","SOP Toggle","Fan Failure Toggle","Spacesuit Pressure Emergency Toggle","No Vent Flow Toggle"};
		// Define minimum and maximum values || toggles (-1 if no toggle) || define state (-1 = low, 0 = nom, 1 = high) [min, max, toggle, state]
		Dictionary<string, string[]> ranges = new Dictionary<string, string[]>()
		{
			{"Battery Capacity",       new string[4]{"0", "30", "-1", "0"}},
			{"Fan Tachometer",         new string[4]{"10000", "40000", "-1", "0"}},
			{"H20 Gas Pressure",       new string[4]{"14", "16", "-1", "0"}},
			//{"H20 Liquid Pressure",    new string[3]{"14", "16", "-1"}},
			{"Internal Suit Pressure", new string[4]{"2", "4", "-1", "0"}},
			{"Oxygen Pressure", 	   new string[4]{"750", "950", "-1", "0"}},
			{"Oxygen Rate", 		   new string[4]{"0.5", "1", "-1", "0"}},
			{"SOP Pressure", 		   new string[4]{"750", "950", "-1", "0"}},
			{"SOP Rate", 			   new string[4]{"0.5", "1", "-1", "0"}},
			{"Sub Pressure",		   new string[4]{"2", "4", "-1", "0"}},
			{"Sub Temperature",   	   new string[4]{"-250", "250", "-1", "0"}},
			{"Time Life Battery",	   new string[4]{"0", "10", "-1", "0"}},
			{"Time Life Oxygen", 	   new string[4]{"0", "10", "-1", "0"}},
			{"Time Life Water", 	   new string[4]{"0", "10", "-1", "0"}},
			{"O2 Off Toggle",          new string[4]{"1", "1", "1", "0"}},
			{"SOP Toggle",             new string[4]{"1", "1", "1", "0"}},
			{"Fan Failure Toggle",     new string[4]{"1", "1", "1", "0"}},
			{"Spacesuit Pressure Emergency Toggle",new string[4]{"1", "1", "1", "0"}},
			{"No Vent Flow Toggle",    new string[4]{"1", "1", "1", "0"}},
		};
		// Define warnings associated with each parameter
		/*Dictionary<string, string> warnings = new Dictionary<string, string>()
		{
			{"Battery Capacity",       "Warning!"},
			{"Fan Tachometer",         "Warning!"},
			{"H20 Gas Pressure",       "Warning!"},
			//{"H20 Liquid Pressure",    "Warning!"},
			{"Internal Suit Pressure", "Warning!"},
			{"Oxygen Pressure", 	   "Warning!"},
			{"Oxygen Rate", 		   "Warning!"},
			{"SOP Pressure", 		   "Warning!"},
			{"SOP Rate", 			   "Warning!"},
			{"Sub Pressure",		   "Warning!"},
			{"Sub Temperature",   	   "Warning!"}, 
			{"Time Life Battery",	   "Warning!"},
			{"Time Life Oxygen", 	   "Warning!"},
			{"Time Life Water", 	   "Warning!"},
			{"O2 Off Toggle",          "Warning!"},
			{"SOP Toggle",             "Warning!"},
			{"Fan Failure Toggle",     "Warning!"},
			{"Spacesuit Pressure Emergency Toggle", "Warning!"},
			{"No Vent Flow Toggle",    "Warning!"},
		};*/
		// store name of text objects in submenus
		Dictionary<string, string[]> subMenuText = new Dictionary<string, string[]>
		{
			{"Submenu - Sub",  new string[]{"Sub Temperature","Sub Pressure"}},
			{"Submenu - Int",  new string[]{"H20 Gas Pressure","Oxygen Pressure","Internal Suit Pressure"}},
			{"Submenu - Misc", new string[]{"Battery Capacity", "Fan Tachometer"}},
			{"Submenu - Sop",  new string[]{"SOP Pressure", "SOP Rate"}},
		};
		// define IP and Port
		NetworkConnect dataStream = new NetworkConnect("127.0.0.1", 5005);
		// store data in structure telemetry
		public Dictionary<string, string> telemetry = new Dictionary<string, string>();
		// define data with nominal ranges and warning descriptions
		public Dictionary<string, Dictionary<string, string>> Data = new Dictionary<string, Dictionary<string, string>>();

		// Function: connect to network
		public void onStart ()
		{
			Debug.Log ("Connecting...");
			dataStream.onStart ();
			Debug.Log ("Connected");
			// pre-define fields of Data and set ranges/warnings messages
			foreach (string info in keys) 
			{
				Data.Add (info, new Dictionary<string, string>{{"value", "0"},{"min",ranges[info][0]},{"max",ranges[info][1]},{"toggle",ranges[info][2]},
					{"status",ranges[info][3]}});
			}
		}
			
		// update telemetry as output in a Update() function || update submenu text objects (passive) || check and update state of each parameter (passive)
		// input: name of submenu selected
		public void updateSub(string selectedSubMenu){
			telemetry = dataStream.onUpdate ();

			// update selected submenu text
			foreach (string name in subMenuText[selectedSubMenu]){
				if(GameObject.Find(name) != null){
					Text selected = GameObject.Find (name).GetComponent<Text> ();
					selected.text = name + ": " + telemetry [name];
				}
			}
		}
		// Function: update telemetry 
		// call in Update()
		public Dictionary<string, Dictionary<string, string>> updateTelemetry(){
			// update value in Data
			foreach (string name in keys) {
				Data [name] ["value"] = telemetry [name];
			}
			return Data;
		}

		// Function: request data value from telmetry by key
		public Dictionary<string, string> dataRequest(string key)
		{
			// update telemetry
		    telemetry = dataStream.onUpdate ();
			// update value in Data
			Data [key] ["value"] = telemetry [key];
			// return data for suit parameter
			return Data [key];
		}

		// Function: act as watch dog on data when outside of nominal range and update warning text object when triggered. 
		// run in Update() 
		public void watchDog(){
			// update telemetry
			telemetry = dataStream.onUpdate ();
			// check status and update text object
			foreach(string name in keys)
			{
				// update value in Data
				Data [name] ["value"] = telemetry [name];
				// check and update status
				if (telemetry [name] != "" && Data [name] ["min"] != "" && Data [name] ["max"] != "") {
					if (Convert.ToDouble (telemetry [name]) < Convert.ToDouble (Data [name] ["min"])) { // too low
						Data [name] ["status"] = "-1";
						// update text object
					}
					if (Convert.ToDouble (telemetry [name]) > Convert.ToDouble (Data [name] ["max"])) { // too high
						Data [name] ["status"] = "1";
						// update text object
					}
					if ((Convert.ToDouble (telemetry [name]) < Convert.ToDouble (Data [name] ["max"]) && (Convert.ToDouble (telemetry [name]) > Convert.ToDouble (Data [name] ["min"])))) {
						Data [name] ["status"] = "0";
					}
				}
			}
		}
			
}
}


