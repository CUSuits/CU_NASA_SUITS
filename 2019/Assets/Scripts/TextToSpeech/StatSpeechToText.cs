using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using HoloToolkit.Unity;

public class StatSpeechToText : MonoBehaviour {
    public TextToSpeech textToSpeechService;
    
    public JSONReader json;
    public SuitData telemetry_data;

    // Use this for initialization
    void Start() {
        json = GameObject.Find("Network Manager").GetComponent<JSONReader>(); 
    }

	public void ReadOutStat(string statRequestName, string readOutName, string units) {
		Debug.Log("Reading out: "+ readOutName);
        telemetry_data = json.suitData;
        string newData = telemetry_data.Request(statRequestName).value;
		if (units != "na") {
			textToSpeechService.StartSpeaking (readOutName + " is currently " + newData + units);
		} else {
			// have read hour min sec...
			string[] parts = newData.Split(':');
			string timeReadOut = parts [0] + " hours " + parts [1] + " minutes and " + parts [2] + " seconds";
			textToSpeechService.StartSpeaking (readOutName + " is currently " + timeReadOut);
		}
    }
}

