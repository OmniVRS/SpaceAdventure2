using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Menu : MonoBehaviour
{
    public string nextLevel;
    public void OnPlayButton ()
    {
        SceneManager.LoadScene(nextLevel);

    }
    public void OnApplicationQuit()
    {
        Application.Quit();
    }
}
