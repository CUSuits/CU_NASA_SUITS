using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTaskManager : InstUpdate, IUpdateText {
    public Text prevStepTextField;
    public Text curStepTextField;
    public Text nextStepTextField;

    public override void UpdateTaskList(Step step) {
        UpdateText(step.hudStr);
        UpdateTextField(step.prevHUDStr, prevStepTextField);
        UpdateTextField(step.nextHUDStr, nextStepTextField);
    }

    public void UpdateText(string newText) {
        curStepTextField.text = newText;
    }

    private void UpdateTextField(string newText, Text textField) {
        Debug.Log(newText);
        if (newText != "") {
            textField.enabled = true;
            textField.text = newText;
        } else {
            textField.enabled = false; 
        }
    }


}
