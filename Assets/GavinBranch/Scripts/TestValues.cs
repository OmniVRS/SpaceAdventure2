using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestValues : MonoBehaviour, IDataPersistence
{
    public int speed = 5;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().SaveGame();
            SceneManager.LoadScene(0);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            GameObject.Find("DataPersistenceManager").GetComponent<DataPersistenceManager>().SaveGame();
            SceneManager.LoadScene(1);
        }
    }

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
