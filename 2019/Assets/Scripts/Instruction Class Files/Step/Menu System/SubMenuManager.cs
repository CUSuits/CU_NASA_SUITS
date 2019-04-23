using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StringSubMenuDict : SerializableDictionary<string, SubMenu> { }


[Serializable]
[CreateAssetMenu(menuName = "Menu System/Create SubMenu Manager")]
public class SubMenuManager : ScriptableObject {

    [SerializeField]
    [Tooltip("Drag in menu stats")]
    public StringSubMenuDict subMenuDictionary;

}
