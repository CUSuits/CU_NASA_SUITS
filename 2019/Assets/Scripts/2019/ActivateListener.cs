using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateListener : MonoBehaviour {
    public GameObject[] gmeObj;
    public Canvas cnvs;
    public SpeechInputHandler speechInputHandler;
	// Use this for initialization
	void Start () {
        gmeObj = UnityEngine.Object.FindObjectsOfType<GameObject>();
      
	}
	
	// Update is called once per frame
	void Update () {
        
    }
    public void ActivateSpeech()
    {
        
        
            foreach (GameObject cs in gmeObj)
            {
                speechInputHandler = cs.GetComponent<SpeechInputHandler>();
                speechInputHandler.enabled = true;
            }
        
       
    }
    public void StopSpeech()
    {
         foreach (GameObject cs in gmeObj)
            {
                speechInputHandler = cs.GetComponent<SpeechInputHandler>();
                speechInputHandler.enabled = false;
            }
        
    }
}
