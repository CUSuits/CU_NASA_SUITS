﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.UI;

public class TaskListManager : InstUpdate, IUpdateText {

    public Image taskImage;
    public Text textField;

    public Text nextStepStr;
    public Text prevStepStr;
    public Image nextImg;
    public Image prevImg;

    public void Start() {
        Debug.Log(nextStepStr.text);

        Debug.Log(prevStepStr.text);
    }

    public override void UpdateTaskList(Step step) {

        if (step.nextStepImg != null) {
            nextImg.sprite = step.nextStepImg;
        } else {
            nextImg.sprite = null;
        }

        if (step.prevStepImg != null) {
            prevImg.sprite = step.nextStepImg;
        } else {
            prevImg.sprite = null;
        }

        if (step.nextStepStr != "") {
            nextStepStr.text = step.nextStepStr;
        } else {
            nextStepStr.text = "";
        }


        if (step.prevStepStr != "") {
            prevStepStr.text = step.prevStepStr;
        } else {
            prevStepStr.text = "";
        }


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
