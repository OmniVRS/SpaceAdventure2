using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExampleSaveScript : MonoBehaviour
{
    public int speed = 5;

    public void LoadData(GameData data)
    {
        this.speed = data.testValue;
        this.transform.position = data.playerPos;
    }
    public void SaveData(ref GameData data)
    {
        data.testValue = speed;
        data.playerPos = transform.position;
    }
}
