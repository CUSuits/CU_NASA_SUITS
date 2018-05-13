using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[CreateAssetMenu()]
public class WatchDogStats : ScriptableObject {
	public List<DataRange> Ranges;
	public List<SwitchStats> Switch;
}
