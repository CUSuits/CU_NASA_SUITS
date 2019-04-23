using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class EMGNew : MonoBehaviour
{

    private string EMGValString;
    private string particleURI;
    public InstructionManager instructionManager;
    public GameObject gameObject;

    IEnumerator GetEMGValue()
    {
        while (true)
        {
            
            // Assign your URI here
            particleURI = "https://api.particle.io/v1/devices/2f0044000f47363336383437/Next?access_token=7f8a497cbeb5a1389ec615ebe61e7e151f60089f";

            // Create a GET web request
            UnityWebRequest EMGStateRequest = UnityWebRequest.Get(particleURI);
            // Wait until the data has been received
            yield return EMGStateRequest.SendWebRequest();
            
            // Make sure you have JSON Object plugin imported
            JSONObject EMGData = new JSONObject(EMGStateRequest.downloadHandler.text);
            // Open the URI link and you can see the value you want is stored in "result", grab this data and store
            EMGData = EMGData["result"];
           
            // Convert the JSON object to a string
            EMGValString = EMGData.ToString();
            Debug.Log(EMGStateRequest.downloadHandler.text);
            if (EMGValString != "\"false\"")
            {
                gameObject.GetComponent<InstructionManager>();
                instructionManager.NextStep();
                Debug.Log("Howdy4");
            }

            // delay 1 second
            yield return new WaitForSeconds(0);
        }
    }

    void Start()
    {
        StartCoroutine(GetEMGValue());
    }
    

}

