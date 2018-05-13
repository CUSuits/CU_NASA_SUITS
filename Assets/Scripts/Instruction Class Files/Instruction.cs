using UnityEngine;
using System.Collections.Generic;
using System;


[Serializable]
[CreateAssetMenu(menuName = "Instructions/Create Instruction")]
public class Instruction : ScriptableObject {

    [Header("Info on Task List")]
    public List<Step> StepList;
    
    //public List<GameObject> GetRecognizedObject(int stepIndex) {
    //    return StepList[stepIndex].recognizedObjects;
    //}

}