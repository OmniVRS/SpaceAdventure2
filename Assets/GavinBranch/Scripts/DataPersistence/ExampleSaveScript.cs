using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// you need to add --------------------------------\ that
public class ExampleSaveScript : MonoBehaviour , IDataPersistence
{
    public int speed = 5;

    public void LoadData(GameData data)
    {
        this.speed = data.testValue;
    }
    public void SaveData(ref GameData data)
    {
        data.testValue = speed;
    }
}
