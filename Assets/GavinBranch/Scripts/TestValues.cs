using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class TestValues : MonoBehaviour
{
    public float speed = 5;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.K))
        {
            SceneManager.LoadScene(1);
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            SceneManager.LoadScene(2);
        }
    }
}
