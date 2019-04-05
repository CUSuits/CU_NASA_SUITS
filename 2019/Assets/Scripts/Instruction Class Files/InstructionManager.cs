using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.Events;
using HoloToolkit.Unity;
using UnityEngine.UI;


[System.Serializable]
public class StepEvent : UnityEvent<Step> {
}

public class InstructionManager : MonoBehaviour {
    public List<Instruction> InstructionList = new List<Instruction>();

    public Dictionary<string, StepEvent> eventDictionary = new Dictionary<string, StepEvent>();

    public Instruction currentInstruction;
    public int currentStep;

    public Instruction pausedInstruction;
    public int pausedStep;

    public TextToSpeech textToSpeechService;
    public bool isReadingOut;


	void UpdateTaskTitle(int instructionIndex)
	{
		int totalSteps = InstructionList [instructionIndex].StepList.Count;
		string title = InstructionList [instructionIndex].nameOfInstruction + " -- Steps: " + Convert.ToString(totalSteps);
		GameObject.Find ("Tasklist Title").GetComponent<Text> ().text = title;
		Debug.Log ("Current Instruction Title: " + title);
    GameObject.Find ("Tasklist Title_cuff").GetComponent<Text> ().text = title;
		Debug.Log ("Current Instruction Title: " + title);
	}

	//Method to publish that Instruction/Step has updated....
    void Awake () {
        if (eventDictionary == null) {
            eventDictionary = new Dictionary<string, StepEvent>();
        }
    }

    #region UnityActions and Delegation
    public void StartListening(string eventName, UnityAction<Step> listener) {
        StepEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.AddListener(listener);
            Debug.Log("Added to dictionary: " + eventName);

        } else {
            thisEvent = new StepEvent();
            thisEvent.AddListener(listener);
            eventDictionary.Add(eventName, thisEvent);
            Debug.Log("Added to dictionary: " + eventName);
        }
    }

    public void StopListening(string eventName, UnityAction<Step> listener) {
        StepEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.RemoveListener(listener);
        }
    }

    public void TriggerEvent(string eventName) {
        StepEvent thisEvent = null;
        if (eventDictionary.TryGetValue(eventName, out thisEvent)) {
            thisEvent.Invoke(currentInstruction.StepList[currentStep]);
        } else {
            Debug.Log("cant find event in dictionary: " + eventName);
        }
    }

    #endregion

    #region Instruction Methods
    /// <summary>
    /// Queue up a new instruction
    /// </summary>
    public void QueueInstruction(string instructionName) {
        //Check if any current instructions?
        //Load new to current
        //set index to 0

    }

    public void QueueInstruction(int instructionIndex) {
        //Check if any current instructions?
        //Load new to current
        currentInstruction = InstructionList[instructionIndex];

		UpdateTaskTitle (instructionIndex);

        //set index to 0
        currentStep = 0;
        Debug.Log(currentInstruction.StepList[currentStep].hudStr);
        TriggerEvent("InstUpdate");
        ReadOutStep();
    }

    public void InterruptInstruction(int newInstruction) {
        //Check if any current instructions?
        if(currentInstruction != null) {
            pausedInstruction = currentInstruction;
            pausedStep = currentStep;
        }

        QueueInstruction(newInstruction);
        TriggerEvent("InstUpdate");
        ReadOutStep();
    }

    public void ResumePausedInstruction() {
        try {
            if(pausedInstruction != null) {
                //Copy paused to current Step
                currentInstruction = pausedInstruction;
                currentStep = pausedStep;

                //Reset Paused Settings
                pausedInstruction = null;
                pausedStep = 0;

                //Execute Current Instruction
                Debug.Log(currentInstruction.StepList[currentStep].hudStr);
            }
            TriggerEvent("InstUpdate");
            ReadOutStep();

			// update title
			int c = 0;

			foreach(Instruction inst in InstructionList){
				if(currentInstruction == inst)
				{
					UpdateTaskTitle(c);
					Debug.Log(c);
				}
				c++;
			}


        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    public void NextStep() {
        try {
            Debug.Log(currentInstruction.StepList[currentStep+1].hudStr);
            ++currentStep;
            TriggerEvent("InstUpdate");
            ReadOutStep();

        }
        catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    public void PreviousStep() {
        try {
            Debug.Log(currentInstruction.StepList[currentStep-1].hudStr);
            --currentStep;
            TriggerEvent("InstUpdate");
            ReadOutStep();

        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    public void SetIsReadOut(bool state) {
        if (state) {
            textToSpeechService.StartSpeaking("Enabling step readout");
        } else {
            textToSpeechService.StartSpeaking("Disabling step readout");
        }
        isReadingOut = state;
    }

    public void ReadOutStep() {
        if (isReadingOut) {
            Debug.Log(currentInstruction.StepList[currentStep].taskListInfo);
            textToSpeechService.StartSpeaking(currentInstruction.StepList[currentStep].taskListInfo);
        }
    }

    public void RepeatStep() {
        textToSpeechService.StartSpeaking(currentInstruction.StepList[currentStep].taskListInfo);
    }
    #endregion
}
