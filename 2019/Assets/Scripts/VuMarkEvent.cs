using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Vuforia;
using HoloToolkit.Unity;

[Serializable]
public class StringGameObjectDict : SerializableDictionary<string, GameObject> { }

public class VuMarkEvent : InstUpdate {

    public List<GameObject> modelList;
    public List<string> modelIdList;

    private int modelN;
    private VuMarkManager vuMarkManager;
    public StringGameObjectDict recognizedObjDict;
    public List<string> trackedTargets;

    public TextToSpeech textToSpeechService;
    void Start() {
        // Set VuMarkManager
        vuMarkManager = TrackerManager.Instance.GetStateManager().GetVuMarkManager();
        // Set VuMark detected and lost behavior methods
        vuMarkManager.RegisterVuMarkDetectedCallback(onVuMarkDetected);
        vuMarkManager.RegisterVuMarkLostCallback(onVuMarkLost);

        foreach (KeyValuePair<string, GameObject> entry in recognizedObjDict) {
            modelList.Add(entry.Value);
        }
        DeactivateAllModels();
    }

    public void DeactivateAllModels() {
        // Deactivate all models 
        foreach (GameObject item in modelList) {
            item.SetActive(false);
        }
    }

    public void NewTrackedTargets(List<string> targetList) {
        //for each target in List hide
        trackedTargets.Clear();
        foreach (string target in targetList)
            trackedTargets.Add(target);
    }

    private string getVuMarkID(VuMarkTarget vuMark) {
        switch (vuMark.InstanceId.DataType) {
            case InstanceIdType.BYTES:
                return vuMark.InstanceId.HexStringValue;
            case InstanceIdType.STRING:
                return vuMark.InstanceId.StringValue;
            case InstanceIdType.NUMERIC:
                return vuMark.InstanceId.NumericValue.ToString();
        }

        return null;
    }

    public void onVuMarkDetected(VuMarkTarget target) {
        Debug.Log("Detected ID: " + getVuMarkID(target));
        textToSpeechService.StartSpeaking(getVuMarkID(target));
        // Find and activate model by VuMark ID
        string objStr = getVuMarkID(target);
        if (recognizedObjDict.ContainsKey(objStr))
            recognizedObjDict[objStr].SetActive(true);

    }

    public void onVuMarkLost(VuMarkTarget target) {
        Debug.Log("Lost ID: " + getVuMarkID(target));
        string objStr = getVuMarkID(target);
        if (recognizedObjDict.ContainsKey(objStr))
            recognizedObjDict[objStr].SetActive(false);
    }

    public override void UpdateTaskList(Step step) {
        DeactivateAllModels();

        List<string> recogObjs = step.recognizedObjectsStr;
        foreach (string obj in recogObjs) {
            Debug.Log(obj);
            if(recognizedObjDict.ContainsKey(obj))
                recognizedObjDict[obj].SetActive(true);
        }

        NewTrackedTargets(step.recognizedObjectsStr);
    }
}