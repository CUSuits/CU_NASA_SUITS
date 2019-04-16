using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using UnityEngine.UI;

public class EMGPhotons : MonoBehaviour
{

    // Create variables 
    private int EMGValue;
    private string EMGString;
    private string particleURI;
    InstructionManager instructionManager;
    public Canvas canvas;
    public GameObject gameobject;

    IEnumerator GetEMGValue()
    {
            // This while loop will repeat as long as our application runs
       
            Debug.Log("Yo");
            // Assign the URI to a variable so that it's easier to handle
            particleURI = "https://api.particle.io/v1/devices/2f0044000f47363336383437/Next?access_token=7f8a497cbeb5a1389ec615ebe61e7e151f60089f";

            // Create a GET web request and store it
            UnityWebRequest EMGWWW = UnityWebRequest.Get(particleURI);
            // Wait until the data has been received before continuing the loop
            yield return EMGWWW.SendWebRequest();
            Debug.Log("Yo");
            // Create a new JSON object from the text we receive back from the request
            JSONObject EMGData = new JSONObject(EMGWWW.downloadHandler.text);
            Debug.Log(EMGWWW.downloadHandler.text);
            Debug.Log(EMGData);

            // Grab the "result" value and store it
            EMGData = EMGData["result"];
            Debug.Log(EMGData);
            // Convert the JSON object to a string so we can parse it to an integer
            //EMGString = EMGData.ToString();
            // Parse the string value to an integer so we can remap it

            //Debug.Log(EMGString);
            // EMGReturnSomething();
            if (EMGData != null)
            {
                //instructionManager.NextStep();
                Debug.Log("                                                                     WAIT");
                
            }


            // Wait for 1 second before restarting the loop 
           // yield return new WaitForSeconds(1);
        

    }

    void Start()
    {
       // Debug.Log("Yo");
       // Get and store the cube's transform
       // Start coroutine to get Particle light data 
       //StartCoroutine(GetEMGValue());
       gameobject.GetComponent<Canvas>();
    }
    void Update()
    {
        StartCoroutine(GetEMGValue());
    }
}
