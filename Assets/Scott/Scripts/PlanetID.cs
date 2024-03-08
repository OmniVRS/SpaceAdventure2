using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlanetID : MonoBehaviour
{
    public string sendToScene;
    public bool hasPlayer;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && hasPlayer)
        {
            //Debug.Log("Clicked!");
            SceneManager.LoadScene(sendToScene);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            hasPlayer = true;  
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        hasPlayer = false;
    }
}
