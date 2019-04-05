using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using Vuforia;
using HoloToolkit.Unity;

[Serializable]
public class StringMarkerDict : SerializableDictionary<string, TrackableMarker> { }

public class TrackableMarkerManager : InstUpdate {
    public List<TrackableMarker> trackableMarkerList;
    public StringMarkerDict recognizedMarkerDict;
    public List<TrackableMarker> trackedTargets;

    private void Start() {
        //Hide all tracked objects on start
        foreach (TrackableMarker trackable in trackableMarkerList)
            trackable.ShowRenderGameObject(false);
    }

    public void AddTracker(TrackableMarker trackable) {
        trackableMarkerList.Add(trackable);
    }


    //Method lets manager know that marker is tracking or not tracking
    public virtual void UpdateTrackState(TrackableMarker trackableMarker, bool isTracked) {
        //if marker tracked and is currently a recognized object, turn on rendering
        if (isTracked) {
            if (trackedTargets.Contains(trackableMarker))
                trackableMarker.ShowRenderGameObject(true);
        } else {
            trackableMarker.ShowRenderGameObject(false);
        }
    }

    //Method called when starting a new Step
    public override void UpdateTaskList(Step step) {
        //Hide all markers
        foreach (TrackableMarker trackable in trackableMarkerList)
            trackable.ShowRenderGameObject(false);

        //Set list of str of newly recognized objects
        List<string> recogObjs = step.recognizedObjectsStr;

        //Turn on renderer for all recognized objects
        foreach (string obj in recogObjs) {
            Debug.Log(obj);
            if (recognizedMarkerDict.ContainsKey(obj)) {
                if (recognizedMarkerDict[obj].GetComponent<TrackableMarker>().GetTrackableState() == TrackableBehaviour.Status.DETECTED || recognizedMarkerDict[obj].GetComponent<TrackableMarker>().GetTrackableState() == TrackableBehaviour.Status.TRACKED)
                    recognizedMarkerDict[obj].ShowRenderGameObject(true);
            } 
        }

        NewTrackedTargets(step.recognizedObjectsStr);
    }


    public void NewTrackedTargets(List<string> targetList) {
        //for each target in List hide
        trackedTargets.Clear();
        foreach (string target in targetList)
            trackedTargets.Add(recognizedMarkerDict[target]);
    }
}
