using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public abstract class BaseItemData : ScriptableObject
{
    public GameObject prefab;

    public Sprite Icon;

    public string Title;

    public string Decription;
}