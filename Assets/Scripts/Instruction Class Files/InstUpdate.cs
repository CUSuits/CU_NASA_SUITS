using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class InstUpdate: MonoBehaviour {
    public string eventName;
    public InstructionManager instructionManager;
    public abstract void UpdateTaskList(Step step);

    void Start() {
        if (eventName == "")
            throw new System.ArgumentException("eventName Listener cannot be null", eventName);
    }

    void OnEnable() {
        //if (InstructionUpdateListener == null) {
        //    Debug.Log("needed to create unity cio");
        //    InstructionUpdateListener = new UnityAction<Step>(InstructionUpdateListener);
        //}
        if (eventName == "") {
            throw new System.ArgumentException("eventName Listener cannot be null", eventName);
        } else {
            instructionManager.StartListening(eventName, UpdateTaskList);
        }
    }

    void OnDisable() {
        if (eventName == "") {
            throw new System.ArgumentException("eventName Listener cannot be null", eventName);
        } else {
            instructionManager.StopListening(eventName, UpdateTaskList);
        }
    }
}
