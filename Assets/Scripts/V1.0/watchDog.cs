using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class watchDog {
	// declaration
	private string value_string; // telemetry info as string
	private double value; // telemetry info as double
	// define keys
	string [] keys = new string[]{"Battery Capacity","Fan Tachometer","H20 Gas Pressure","H20 Liquid Pressure","Internal Suit Pressure",
		"Oxygen Pressure","Oxygen Rate","SOP Pressure", "SOP Rate","Sub Pressure","Sub Temperature","Time Life Battery","Time Life Oxygen","Time Life Water"};
	// define suit parameters and their expected values MISSING: H20 liquid pressure in telemetry
	Dictionary<string, double[]> expected = new Dictionary<string, double[]>()
	{
		{"Battery Capacity",       new double[2]{0, 30}},
		{"Fan Tachometer",         new double[2]{10000, 40000}},
		{"H20 Gas Pressure",       new double[2]{14, 16}},
		{"H20 Liquid Pressure",    new double[2]{14, 16}},
		{"Internal Suit Pressure", new double[2]{2, 4}},
		{"Oxygen Pressure", 	   new double[2]{750, 950}},
		{"Oxygen Rate", 		   new double[2]{0.5, 1}},
		{"SOP Pressure", 		   new double[2]{750, 950}},
		{"SOP Rate", 			   new double[2]{0.5, 1}},
		{"Sub Pressure",		   new double[2]{2, 4}},
		{"Sub Temperature",   	   new double[2]{-250, 250}}, // standard low earth orbit day and night cycles
		{"Time Life Battery",	   new double[2]{0, 10}},
		{"Time Life Oxygen", 	   new double[2]{0, 10}},
		{"Time Life Water", 	   new double[2]{0, 10}},
	};
	/* handle toggles... 
	{"O2 Off Toggle", },
	{"SOP Toggle", },
	{"Fan Failure Toggle", },
	{"Spacesuit Presser Emergency Toggle",},
	{"No Vent Flow Toggle",    new int[2]{ , }},
	MORE TOGGLES BASED ON TELEMETRY MANUAL and see limits there
	*/

	/// <summary>
	///  call in Update() with input of telemetry dictionary and a key to fields in telemetry
	/// </summary>
	/*void checkRequest(Dictionary<string, string> telemetry){
	    string warnings;     // store all string names out of range
		// check each value in telemetry against nominal range
		foreach (string field in keys) {
			value_string = telemetry [field];
			value = Convert.ToDouble (value_string);
			if(value < expected[field][0]){
				
			}

		}
		// trigger text object warning when out of range... can make another function for this action
	}*/

	/// <summary>
	///  call in Update() with input of telemetry dictionary 
	/// </summary>
	/// return: dictionary with same keys as expected and rather the current value is nominal or not
	//void checkToggle(Dictionary<string, string> telemetry){
		// trigger text object warning if toggled negatively
//	}

//}
}

