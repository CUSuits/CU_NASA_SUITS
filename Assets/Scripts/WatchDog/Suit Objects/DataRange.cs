using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu()]
public class DataRange : ScriptableObject {
	public string reference;
	public double min;
	public double max;
	public double cautionMin;
	public double cautionMax;
}

