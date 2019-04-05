using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/// <summary>
/// Class to store all switch data
/// </summary>
[System.Serializable]
public class SwitchData {
	public string sop_on;
	public string sspe;
	public string fan_error;
	public string vent_error;
	public string vehicle_power;
	public string h2o_off;
	public string o2_off;

    // return data on request
    public SwitchInfo Request(string selected)
    {
        // store all relavant data in a dictionary
        Dictionary<string, SwitchInfo> storeSwitchInfo = new Dictionary<string, SwitchInfo>
        {
            { "sop_on", new SwitchInfo { nominal = "false", title = "SOP On", value = sop_on} },
            { "sspe", new SwitchInfo { nominal = "false", title = "SSPE", value = sspe }},
            { "fan_error", new SwitchInfo { nominal = "false", title = "Fan Error", value = fan_error } },
            { "vent_error", new SwitchInfo { nominal = "false", title = "Vent Error", value = vent_error } },
            { "vehicle_power", new SwitchInfo { nominal = "false", title = "Vehicle Power", value = vehicle_power } },
            { "h2o_off", new SwitchInfo { nominal = "false", title = "H2O Off", value = h2o_off } },
            { "o2_off", new SwitchInfo { nominal = "false", title = "O2 Off", value = o2_off } },
        };
        // return requested data
        switch (selected)
        {
            case "sop_on": return storeSwitchInfo[selected];
            case "sspe": return storeSwitchInfo[selected];
            case "fan_error": return storeSwitchInfo[selected];
            case "vent_error": return storeSwitchInfo[selected];
            case "vehicle_power": return storeSwitchInfo[selected];
            case "h2o_off": return storeSwitchInfo[selected];
            case "o2_off": return storeSwitchInfo[selected];
        }
        return null;
    }
}