using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DontDestroyOnLoad : MonoBehaviour
{
    private List<int> levelsWithSpaceShip;
    private void Awake()
    {
        levelsWithSpaceShip = new List<int>
        {
            1,
            2
        };
        DontDestroyOnLoad(this);
    }

    private void OnLevelWasLoaded(int level)
    {
        foreach (int i in levelsWithSpaceShip)
        {
            if(SceneManager.GetActiveScene().buildIndex == levelsWithSpaceShip[i])
            {
                this.gameObject.SetActive(false);
            }
            else
            {
                this.gameObject.SetActive(true);
            }
        }
    }
}
