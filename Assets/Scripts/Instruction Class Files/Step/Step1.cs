using UnityEngine;
using System.Collections.Generic;
using System;


[Serializable]
public struct Step1 {

    [Header("Info on Task List")]
    public string taskListInfo;
    public Sprite taskListImg;
    

    [Header("Info on HUD")]
    public string prevHUDStr;
    public string hudStr;
    public string nextHUDStr;

    [Header("Objects Recognized")]
    public List<GameObject> recognizedObjects;

    public List<string> recognizedObjectsStr;
}