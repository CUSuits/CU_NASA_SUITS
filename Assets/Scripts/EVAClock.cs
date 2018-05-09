using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class EVAClock : MonoBehaviour {
    public DateTime startTime;
    public DateTime currentTime;
    public TimeSpan elapsed;
    private Text textLabel;

    // Use this for initialization
    void Start () {
        startTime = DateTime.Now;
        textLabel = this.GetComponentInChildren<Text>();
        textLabel.text = "00:00:00";
    }
	
	// Update is called once per frame
	void Update () {

        currentTime = DateTime.Now;
        elapsed = currentTime.Subtract(startTime);
        string s = new DateTime(elapsed.Ticks).ToString("HH:mm:ss");
        textLabel.text = s;
    }
}
