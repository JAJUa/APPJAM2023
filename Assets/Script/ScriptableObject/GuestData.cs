using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "º’¥‘ µ•¿Ã≈Õ", menuName = "Scriptable Object/º’¥‘ µ•¿Ã≈Õ", order = int.MinValue)]
public class GuestData : ScriptableObject
{
    public GuestAct[] goodReaction;
    public GuestAct[] badReaction;
}

[Serializable]
public struct GuestAct
{
    public string text;
    public Sprite sprite;
}
