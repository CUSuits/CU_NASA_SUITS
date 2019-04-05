using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HUDTaskManager : InstUpdate, IUpdateText {
    public Text prevStepTextField;
    public Text curStepTextField;
    public Text nextStepTextField;
    public Image nextStepIMG;
    public Image prevStepIMG;
    public Image currentImage;
    public Text caution;
    public Text warning;

    public override void UpdateTaskList(Step step) {
        if (step.nextStepImg != null)
        {
            nextStepIMG.sprite = step.nextStepImg;
        }
        else {
            nextStepIMG.sprite = null;
        }
        if (step.prevStepImg != null)
        {
            prevStepIMG.sprite = step.prevStepImg;
        }
        else
        {
            prevStepIMG.sprite = null;
        }
        UpdateText(step.hudStr);
        UpdateTextField(step.prevHUDStr, prevStepTextField);
        UpdateTextField(step.nextHUDStr, nextStepTextField);
        UpdateImage(step.taskListImg);

    }

    public void UpdateText(string newText) {
        curStepTextField.text = newText;
    }

    private void UpdateTextField(string newText, Text textField) {
        if (newText != "") {
            textField.enabled = true;
            textField.text = newText;
        } else {
            textField.enabled = false; 
        }
    }
    public void UpdateImage(Sprite newSprite)
    {
        currentImage.sprite = newSprite;
    }


}
