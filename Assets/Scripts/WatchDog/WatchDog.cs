using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WatchDog : MonoBehaviour{
	// set scriptable objects (nominal ranges/toggle library and menu stat object library)
	public WatchDogStats watchDogStats;
	// import public dictionary of all menu stats - menu stat dictionary
	public MenuStatManager menuStatDictionary;
	// store nominal ranges
	private List<DataRange> dataRanges;
	private List<SwitchStats> switchNom;
	// store current telemetry values
	private string current_val;
	private string current_switch;
	// telemetry time holder
	private string hour;
	// pad manager
	public SubMenuPadBehavior padManager;

	void Start()
	{
	
	}
		
	/// <summary>
	/// check suit and switch telemetry values againts nominal ranges, update pad with warnings
	/// </summary>
	/// <param name="telemetry_suit">Telemetry suit.</param>
	/// <param name="telemetry_switch">Telemetry switch.</param>
	public void DeployWatchDog(SuitData telemetry_suit, SwitchData telemetry_switch){
		// extract list of suit data ranges and switch nominal values
		dataRanges = watchDogStats.Ranges;
		switchNom = watchDogStats.Switch;
		//----------------------------------------
		// suit data -----------------------------
		//----------------------------------------
		foreach (DataRange range in dataRanges)
		{
			if(telemetry_suit.Request(range.reference).value != "") // if telemetry value exists
			{
				// componsate for time syntax
				if(range.reference == "t_water" || range.reference == "t_oxygen" || range.reference == "t_battery"){
					current_val = Time2Value(telemetry_suit.Request("t_water").value);
				}else{
					current_val = telemetry_suit.Request (range.reference).value; // define telemetry value 
				}
				if(Convert.ToDouble(current_val) > range.max || Convert.ToDouble(current_val) < range.min) // check ranges
				{
                    // push menu stat to pad...
                    try {

                        padManager.Push(menuStatDictionary.subMenuDictionary[range.reference]);
                    } catch {
                        Debug.LogError("cant find menu stat from DataRange reference name");
                    }
				}
			}
		}
		//----------------------------------------
		// switch data ---------------------------
		//----------------------------------------
		foreach(SwitchStats nominal in switchNom)
		{
			if (telemetry_switch.Request (nominal.reference).value != "") // if telemetry value exists
			{
				current_switch = telemetry_switch.Request (nominal.reference).value; // define telemetry value 
				if (nominal.nominal != current_switch) // check nominal
				{
                    // push menu stat to pad...
                    try {

                        padManager.Push(menuStatDictionary.subMenuDictionary[nominal.reference]);
                    } catch {
                        Debug.LogError("cant find switch stat from DataRange reference name");
                    }
                }
			}
		}
	}
	// make some type of count so that if things are not bad the pad is cleared...

	public string Time2Value(string time)
	{
		string[] parts = time.Split (':');
		string hour = parts [0];
		return hour;
	}
} 
