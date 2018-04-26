using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TaskListManager : InstUpdate, IUpdateText {

    public Image taskImage;
    public Text textField;

    public override void UpdateTaskList(Step step) {
        UpdateText(step.taskListInfo);
        UpdateImage(step.taskListImg);
    }

    public void UpdateText(string newText) {
        textField.text = newText;
    }

    public void UpdateImage(Sprite newSprite) {
        taskImage.sprite = newSprite; ;
    }
}
