using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class WatchDog : MonoBehaviour{
	// set scriptable objects (nominal ranges/toggle library and menu stat object library)
	public WatchDogStats watchDogStats;
	// import public dictionary of all menu stats - menu stat dictionary
	public MenuStatManager menuStatDictionary;
	public SwitchStatManager switchStatDictionary;
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
	// warnings manager
	public WarningsHandler warningManager;

	public string userInput;

		
	void Start()
	{
		if (padManager == null || warningManager == null) 
		{
			Debug.LogError ("Missing Pad Manager or Warning Manager Script");
		}
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
			try
			{
				if(telemetry_suit.Request(range.reference).value != "") // if telemetry value exists
				{
					// componsate for time syntax
					if(range.reference == "t_water" || range.reference == "t_oxygen" || range.reference == "t_battery"){
						current_val = Time2Value(telemetry_suit.Request(range.reference).value);
					}else{
						current_val = telemetry_suit.Request (range.reference).value; // define telemetry value 
					}

					// check if warning is triggered
					CheckSuitWarnings(range, current_val);
				}
			}catch
			{
				//Debug.Log("Not connected to suit data server, please confirm IP address is correct");
			}
		}
		//----------------------------------------
		// switch data ---------------------------
		//----------------------------------------
		try
		{
			foreach(SwitchStats nominal in switchNom)
			{
				if (telemetry_switch.Request (nominal.reference).value != "") // if telemetry value exists
				{
					current_switch = telemetry_switch.Request (nominal.reference).value; // define telemetry value 
					// check if switch is not nominal
					CheckSwitchWarnings (nominal, current_switch);
				}
			}
		}catch
		{
			Debug.Log("Not connected to switch data server, please confirm IP address is correct");
		}
	}

	//------------------------------------
	// Supporting Functions --------------
	//------------------------------------

	// make some type of count so that if things are not bad the pad is cleared...
	public string Time2Value(string time)
	{
		string[] parts = time.Split (':');
		string hour = parts [0];
		return hour;
	}
		
	// check if suit data is out of range
	void CheckSuitWarnings(DataRange range, string current_val)
	{
		if (Convert.ToDouble (current_val) > range.max || Convert.ToDouble (current_val) < range.min) { // check ranges
			// push menu stat to pad...
			try {
				warningManager.PushWarningStat (menuStatDictionary.subMenuDictionary [range.reference]); 
			} catch {
				Debug.LogError ("cant find menu stat from DataRange reference name");
			}
		} else {
			MenuStat removeStat = menuStatDictionary.subMenuDictionary [range.reference];
			bool isStatOnPad = warningManager.CheckStatOnPad(removeStat);
			if (isStatOnPad) {
				warningManager.Clear (removeStat);
			}
		}
	}

	// check if switch is triggered
	void CheckSwitchWarnings(SwitchStats nominal, string current_switch)
	{
		
		if (nominal.nominal != current_switch) { // check nominal
			SwitchStat newSwitchStat = null;
			// push menu stat to pad...
			try {
				padManager.PushEmergencyStat(menuStatDictionary.subMenuDictionary[nominal.reference]);
				newSwitchStat = switchStatDictionary.switchDictionary [nominal.reference]; 
			} catch {
				Debug.LogError ("cant find switch stat from DataRange reference name: " + nominal.reference);
			}
			try {
				warningManager.PushWarningSwitch (newSwitchStat);
			} catch {
				Debug.LogError ("Could not push warning for switch");
			}
		} else {
			SwitchStat removeSwitchStat = switchStatDictionary.switchDictionary [nominal.reference];
			bool isStatOnPad = warningManager.CheckStatOnPad(removeSwitchStat);
			if (isStatOnPad) {
				warningManager.Clear (removeSwitchStat);
			}
		}
	}

	void RemoveStatFromPad(){
	}
		

} 
