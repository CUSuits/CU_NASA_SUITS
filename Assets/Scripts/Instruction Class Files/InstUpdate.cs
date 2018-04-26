using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstUpdate: MonoBehaviour {
    public string eventName;
    public InstructionManager instructionManager;
    public abstract void UpdateTaskList(Step step);

    void OnEnable() {
        //if (InstructionUpdateListener == null) {
        //    Debug.Log("needed to create unity cio");
        //    InstructionUpdateListener = new UnityAction<Step>(InstructionUpdateListener);
        //}
        if (eventName == null) {
            throw new System.ArgumentException("eventName Listener cannot be null", eventName);
        } else {
            instructionManager.StartListening(eventName, UpdateTaskList);
        }

    }

    void OnDisable() {
        if (eventName == null) {
            throw new System.ArgumentException("eventName Listener cannot be null", eventName);
        } else {
            instructionManager.StopListening(eventName, UpdateTaskList);
        }
    }
}
