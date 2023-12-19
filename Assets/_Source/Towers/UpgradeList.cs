using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using AYellowpaper.SerializedCollections;

[Serializable]
public class UpgradeList
{
    public SerializedDictionary<string, List<Vector2>> _categories;
}
