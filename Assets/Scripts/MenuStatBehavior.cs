using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MenuStatBehavior : MonoBehaviour {
    public MenuStat menuStat;
    public Text statTextField;

	// Use this for initialization
	void Start () {
        statTextField = GetComponent<Text>();
	}

    void UpdateText(string newValue) {
        statTextField.text = newValue;
    }

    public void InitializeMenuStat(MenuStat newMenuStat) {
        menuStat = newMenuStat;
    }

    string RequestNewData(string requestParam) {
        string newData = menuStat.name;
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
        UpdateText(menuStat.name+" : "+newData);
	}
 }
