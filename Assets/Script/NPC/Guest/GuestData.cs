using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "�մ� ������", menuName = "Scriptable Object/�մ� ������", order = int.MinValue)]
public class GuestData : ScriptableObject
{
    public Sprite defaultSprite;
    public Sprite infoSprite;
    public Foods[] neededFood;

    public GuestAct[] startAct;
    public GuestAct[] waitAct;
    public GuestAct[] goodReaction;
    public GuestAct[] badReaction;
}

[Serializable]
public struct GuestAct
{
    [TextArea]
    public string text;
    public Sprite guestSprite;
    public AudioClip clip;
}
