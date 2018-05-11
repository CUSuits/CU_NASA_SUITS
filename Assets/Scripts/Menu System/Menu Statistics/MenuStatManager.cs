using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StringMenuStatDict : SerializableDictionary<string, MenuStat> { }


[Serializable]
[CreateAssetMenu(menuName = "Menu System/Create MenuStat Manager")]
public class MenuStatManager : ScriptableObject {

    [SerializeField]
    [Tooltip("Drag in menu stats")]
    public StringMenuStatDict subMenuDictionary;

}
