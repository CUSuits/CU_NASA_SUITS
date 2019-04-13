using HoloToolkit.Unity.InputModule;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EchoManager : MonoBehaviour {
    public SpeechInputHandler speechInputHandler;
    public CanvasSpeechInputHandler canvasSpeechInputHandler;
    public GameObject[] activateGameObject;
    public GameObject justOne;
    public GameObject ugh;
    public bool truth;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (truth) {
            activateGameObject = GameObject.FindGameObjectsWithTag("HeyAlexa");
            for (int i = 0; i < activateGameObject.Length; i++)
            {
                activateGameObject[i] = justOne;
                justOne.GetComponent<CanvasSpeechInputHandler>();
                justOne.enabled = true;
             

            }
        }
    }
    public bool HeyHololens()
    {
        truth = true;
        return truth; 
    }
}
