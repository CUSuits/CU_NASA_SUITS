using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatBehavior : MonoBehaviour {
    public MenuStat menuStat;
    public Text statTextField;

    public JSONReader json;
    public SuitData telemetry_data;

	// Use this for initialization
	void Start () {
        statTextField = GetComponent<Text>();
        json = GameObject.Find("Network Manager").GetComponent<JSONReader>();
	}

    void UpdateText(string newValue) {
        statTextField.text = newValue;
    }

    public void InitializeMenuStat(MenuStat newMenuStat) {
        menuStat = newMenuStat;
    }

    string RequestNewData(string requestParam) {
        string newData;
        if (requestParam == "--")
        {
            newData = "";
        } else
        { 
        telemetry_data = json.suitData;
        newData = telemetry_data.Request(requestParam).value;
        };
        return newData;
    }

    string GetRequestParam() {
        if (menuStat != null) {
            return menuStat.dataRequestName;
        } else {
            Debug.Log("no request param");
            return "no param";
        }
    }
    
    void Update () {
        //Delay request to every 1 second?
        string requestParam = GetRequestParam();
        string newData = RequestNewData(requestParam);
        if (requestParam == "--")
        {
            UpdateText(menuStat.name);
        }
        else
        {
            UpdateText(menuStat.name + " : " + newData);
        };
    }
 }
