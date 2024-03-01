using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class GameData
{
    //stuff we want to store
    public int testValue;
    public Vector2 playerPos;
    public Dictionary<string, bool> GadgetsCollected;

    //values set in here will be the default
    public GameData()
    {
        this.testValue = 0;
        playerPos = Vector2.zero;
        GadgetsCollected = new Dictionary<string, bool>();  
    }
}
