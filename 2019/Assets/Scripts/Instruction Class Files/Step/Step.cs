using UnityEngine;
using System.Collections.Generic;
using System;


[Serializable]
[CreateAssetMenu(menuName = "Instructions/Create Step")]
public class Step : ScriptableObject {

    [Header("Info on Task List")]
	public int stepNumber;
    public string taskListInfo;
    public Sprite taskListImg;
    public string prevStepStr;
    public Sprite prevStepImg;
    public string nextStepStr;
    public Sprite nextStepImg;
    public string warning;
    public string caution;

    [Header("Info on HUD")]
    public string prevHUDStr;
    public string hudStr;
    public string nextHUDStr;

    [Header("Objects Recognized")]
    //public List<GameObject> recognizedObjects;
    
    public List<string> recognizedObjectsStr;
}