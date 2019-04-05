using UnityEditor;
using UnityEngine;
using System.Collections.Generic;

[CustomEditor(typeof(SubMenuBehavior))]
public class SubMenuBehaviorEditor : Editor {

    SubMenuBehavior comp;


    private void OnEnable() {
    }

    public override void OnInspectorGUI() {
        DrawDefaultInspector();
    
        SubMenuBehavior subMenuBehavior = (SubMenuBehavior)target;
        if (GUILayout.Button("Create Submenu")) {
            subMenuBehavior.Create();
        }
    }

}
