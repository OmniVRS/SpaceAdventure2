using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RunOnSceneSwitch : MonoBehaviour
{
    public int sceneToLoad;
    private void Awake()
    {
        SceneManager.LoadScene(sceneToLoad);
    }
}
