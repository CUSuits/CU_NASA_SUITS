/*==============================================================================
Copyright (c) 2017 PTC Inc. All Rights Reserved.

Copyright (c) 2010-2014 Qualcomm Connected Experiences, Inc.
All Rights Reserved.
Confidential and Proprietary - Protected under copyright and other laws.
==============================================================================*/

using UnityEngine;
using Vuforia;

/// <summary>
///     A custom handler that implements the ITrackableEventHandler interface.
/// </summary>
/// 
public class TrackableMarker : MonoBehaviour, ITrackableEventHandler {
    #region PRIVATE_MEMBER_VARIABLES

    protected TrackableBehaviour mTrackableBehaviour;
    //public GameObject renderGameObject;
    private TrackableMarkerManager trackManager;


    #endregion // PRIVATE_MEMBER_VARIABLES

    #region UNITY_MONOBEHAVIOUR_METHODS

    private void Awake() {
        try {
            trackManager = GetComponentInParent<TrackableMarkerManager>();
            trackManager.AddTracker(this);
        } catch {
            Debug.LogError("TrackManager not set");
        }
    }

    protected virtual void Start() {
        mTrackableBehaviour = GetComponent<TrackableBehaviour>();
        if (mTrackableBehaviour)
            mTrackableBehaviour.RegisterTrackableEventHandler(this);
    }

    #endregion // UNITY_MONOBEHAVIOUR_METHODS

    #region PUBLIC_METHODS

    /// <summary>
    ///     Implementation of the ITrackableEventHandler function called when the
    ///     tracking state changes.
    /// </summary>
    public void OnTrackableStateChanged(
        TrackableBehaviour.Status previousStatus,
        TrackableBehaviour.Status newStatus) {
        if (newStatus == TrackableBehaviour.Status.DETECTED ||
            newStatus == TrackableBehaviour.Status.TRACKED) {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " found");
            OnTrackingFound();
        } else if (newStatus == TrackableBehaviour.Status.EXTENDED_TRACKED) {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " extended tracking");
            OnExtendedTracking();
        } else if (((previousStatus == TrackableBehaviour.Status.TRACKED) || (previousStatus == TrackableBehaviour.Status.EXTENDED_TRACKED)) &&
                     newStatus == TrackableBehaviour.Status.NOT_FOUND) {
            Debug.Log("Trackable " + mTrackableBehaviour.TrackableName + " lost");
            OnTrackingLost();
        } else {
            // For combo of previousStatus=UNKNOWN + newStatus=UNKNOWN|NOT_FOUND
            // Vuforia is starting, but tracking has not been lost or found yet
            // Call OnTrackingLost() to hide the augmentations
            OnTrackingLost();
        }
    }

    public TrackableBehaviour.Status GetTrackableState() {
        return mTrackableBehaviour.CurrentStatus;
    }

    public void ShowRenderGameObject(bool state) {
        //var renderer = renderGameObject.GetComponentsInChildren<Renderer>(true);

        //// Enable rendering:
        //foreach (var component in renderer)
        //    component.enabled = state;

        Canvas[] canvasChildren = GetComponentsInChildren<Canvas>();
        foreach (Canvas canvas in canvasChildren)
            canvas.enabled = state;
    }

    #endregion // PUBLIC_METHODS

    #region PRIVATE_METHODS

    protected virtual void OnTrackingFound() {
        SignalTracked(true);
    }

    protected virtual void OnExtendedTracking() {

    }

    protected virtual void OnTrackingLost() {
        SignalTracked(false);
    }

    private void SignalTracked(bool state) {
        trackManager.UpdateTrackState(this, state);
    }
    #endregion // PRIVATE_METHODS
}
