using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;


[CustomPropertyDrawer(typeof(StringGameObjectDict))]
[CustomPropertyDrawer(typeof(StringSubMenuDict))]
[CustomPropertyDrawer(typeof(StringMenuStatDict))]
[CustomPropertyDrawer(typeof(StringStringDictionary))]
[CustomPropertyDrawer(typeof(ObjectColorDictionary))]
[CustomPropertyDrawer(typeof(StringMarkerDict))]
[CustomPropertyDrawer(typeof(StringSwitchStatDict))]
public class AnySerializableDictionaryPropertyDrawer : SerializableDictionaryPropertyDrawer {}
