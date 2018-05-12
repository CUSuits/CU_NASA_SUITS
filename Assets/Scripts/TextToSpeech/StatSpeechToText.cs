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

    public void ReadOutStat(string statRequestName) {
        Debug.Log("Reading out: "+statRequestName);
        telemetry_data = json.suitData;
        string newData = telemetry_data.Request(statRequestName).value;
        textToSpeechService.StartSpeaking(statRequestName+" is currently "+ newData);
    }
}

