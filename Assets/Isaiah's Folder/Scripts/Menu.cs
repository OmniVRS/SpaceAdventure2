using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public void OnPlayButton ()
    {
        SceneManager.LoadScene("Level 1");

    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
