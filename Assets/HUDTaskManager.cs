using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTaskManager : InstUpdate, IUpdateText {
    public Text textField;
  

    public override void UpdateTaskList(Step step) {
        Debug.Log("Triggered2");
        UpdateText(step.hudStr);
   }

    public void UpdateText(string newText) {
        textField.text = newText;
    }
}
