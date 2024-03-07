using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelsStarmap : MonoBehaviour
{
    public GameObject player;
    private string selectedLevel;
    public string starMapScene = "StarMap";
    public string BluePlanetScene;
    public string AsteroidBeltScene;
    public string TechPlanetScene;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && selectedLevel != null)
        {
            SceneManager.LoadScene(starMapScene);
        }
    }

    
}
