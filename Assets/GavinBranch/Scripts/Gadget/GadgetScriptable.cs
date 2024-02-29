using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "Item", menuName = "Scriptable Gadget")]
public class GadgetScriptable : ScriptableObject
{
    [Header("Properties")]
    public Sprite gadgetSprite;
    public itemType item_type;
}

public enum itemType {PersonalTractorBeam, GravSwitch, Radar}
