using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(menuName = "Menu System/Create SubMenu")]
public class SubMenu : ScriptableObject {

    [Tooltip("SubMenu Title")]
    public string subMenuTitle;
    [Tooltip("Drag in menu stats")]
    public List<MenuStat> subMenuItems;
}
