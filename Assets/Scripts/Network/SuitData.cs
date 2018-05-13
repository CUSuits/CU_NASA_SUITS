using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to store all suit data
/// </summary>
[System.Serializable]
public class SuitData {
	public string heart_bpm;
	public string p_suit;
	public string p_sub;
	public string t_sub;
	public string v_fan;
	public string p_o2;
	public string rate_o2;
	public string cap_battery;
	public string p_h2o_g;
	public string p_h2o_l;
	public string p_sop;
	public string rate_sop;
	public string t_battery;
	public string t_oxygen;
	public string t_water;


    // ------------------------------------------
    // return data on request
    // ------------------------------------------
    public SuitInfo Request(string selected)
    {
        // store all relavant data in a dictionary
        Dictionary<string, SuitInfo> storeSuitInfo = new Dictionary<string, SuitInfo>
        {
            {"heart_bpm", new SuitInfo { min = 1, max = 1, title = "Heart Rate", value = heart_bpm}},
            { "p_suit",  new SuitInfo { min = 1, max = 1, title = "Suit Pressure", value = p_suit}},
            { "p_sub", new SuitInfo { min = 1, max = 1, title = "SUB Pressure", value = p_sub}},
            { "t_sub", new SuitInfo { min = 1, max = 1, title = "SUB Temperature", value = t_sub}},
            { "v_fan", new SuitInfo { min = 1, max = 1, title = "Fan Tachometer", value = v_fan}},
            { "p_o2", new SuitInfo { min = 1, max = 1, title = "Oxygen Pressure", value = p_o2}},
            { "rate_o2", new SuitInfo { min = 1, max = 1, title = "Oxygen Rate", value = rate_o2}},
            { "cap_battery", new SuitInfo { min = 1, max = 1, title = "Battery Capacity", value = cap_battery}},
            { "p_h2o_g", new SuitInfo { min = 1, max = 1, title = "H2O Gas Pressure", value = p_h2o_g}},
            { "p_h2o_l", new SuitInfo { min = 1, max = 1, title = "H2O Liquid Pressure", value = p_h2o_l}},
            { "p_sop", new SuitInfo { min = 1, max = 1, title = "SOP Pressure", value = p_sop}},
            { "rate_sop", new SuitInfo { min = 1, max = 1, title = "SOP Rate", value = rate_sop}},
            { "t_battery", new SuitInfo { min = 1, max = 1, title = "Battery Time", value = t_battery}},
            { "t_oxygen", new SuitInfo { min = 1, max = 1, title = "Oxygen Time", value = t_oxygen}},
            { "t_water", new SuitInfo { min = 1, max = 1, title = "Water Time", value = t_water}},
        };
        // return requested data
        switch (selected)
        {
            case "heart_bpm": return storeSuitInfo[selected];
            case "p_suit": return storeSuitInfo[selected];
            case "p_sub": return storeSuitInfo[selected];
            case "t_sub": return storeSuitInfo[selected];
            case "v_fan": return storeSuitInfo[selected];
            case "p_o2": return storeSuitInfo[selected];
            case "rate_o2": return storeSuitInfo[selected];
            case "cap_battery": return storeSuitInfo[selected];
            case "p_h2o_g": return storeSuitInfo[selected];
            case "p_h2o_l": return storeSuitInfo[selected];
            case "p_sop": return storeSuitInfo[selected];
            case "rate_sop": return storeSuitInfo[selected];
            case "t_battery": return storeSuitInfo[selected];
            case "t_oxygen": return storeSuitInfo[selected];
            case "t_water": return storeSuitInfo[selected];
        }
        return null;
    }


}
