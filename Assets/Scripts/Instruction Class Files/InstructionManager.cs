using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class InstructionManager : MonoBehaviour {
    [SerializeField]
    public Dictionary<string,Instruction> Instructions = new Dictionary<string, Instruction>();
    public List<Instruction> InstructionList = new List<Instruction>();


    public Instruction currentInstruction;
    public int currentStep;

    public Instruction pausedInstruction;
    public int pausedStep;


    //Method to publish that Instruction/Step has updated....
    //??

	// Use this for initialization
	void Start () {
		
	}

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

        //set index to 0
        currentStep = 0;

        Debug.Log(currentInstruction.StepList[currentStep].hudStr);
    }

    public void InterruptInstruction(int newInstruction) {
        //Check if any current instructions?
        if(currentInstruction != null) {
            pausedInstruction = currentInstruction;
            pausedStep = currentStep;
        }

        QueueInstruction(newInstruction);
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
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    public void NextStep() {
        try {
            Debug.Log(currentInstruction.StepList[currentStep+1].hudStr);
            ++currentStep;
        }
        catch (Exception e) {
            Debug.LogException(e, this);
        }
    }

    public void PreviousStep() {
        try {
            Debug.Log(currentInstruction.StepList[currentStep-1].hudStr);
            --currentStep;
        } catch (Exception e) {
            Debug.LogException(e, this);
        }
    }
}
