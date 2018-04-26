using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstructionDispatcher : MonoBehaviour {
    public InstructionManager instManager;
	// Use this for initialization
	void Start () {
		
	}

    public void InputHandler() {
        if (Input.GetKeyDown(KeyCode.Alpha0)) {
            instManager.QueueInstruction(0);
        }
        if (Input.GetKeyDown(KeyCode.Alpha1)) {
            instManager.QueueInstruction(1);
        }
        if (Input.GetKeyDown(KeyCode.A)) {
            instManager.InterruptInstruction(0);
        }
        if (Input.GetKeyDown(KeyCode.S)) {
            instManager.ResumePausedInstruction();
        }

    }
	
	// Update is called once per frame
	void Update () {
        InputHandler();
    }
}
