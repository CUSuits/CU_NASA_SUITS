﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
[CreateAssetMenu(menuName = "Menu System/Create Menu Stat")]
public class MenuStat : ScriptableObject {
    [Tooltip("Name used in stat label")]
    public string name;
    [Tooltip("Short hand name used to request data from server")]
    public string dataRequestName;
}
