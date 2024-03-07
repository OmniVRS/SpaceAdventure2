using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player.transform.position.y >= -3.9 && player.transform.position.y <= 3.9)
        {
            transform.position = new Vector2(transform.position.x, player.transform.position.y);
        }
    }
}
