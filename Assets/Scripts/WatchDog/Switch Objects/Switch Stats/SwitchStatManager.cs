using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class StringSwitchStatDict : SerializableDictionary<string, SwitchStat> { }


[Serializable]
[CreateAssetMenu(menuName = "Menu System/Create Switch Stat Manager")]
public class SwitchStatManager : ScriptableObject {

	[SerializeField]
	[Tooltip("Drag in switch stats")]
	public StringSwitchStatDict switchDictionary;

}