using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class EnterUFO : MonoBehaviour
{
    public CinemachineVirtualCamera virtualCamera;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Player"))
        {
            Destroy(collision.gameObject);
            GetComponent<PlayerMovement>().enabled = true;
            virtualCamera.LookAt = transform;
            virtualCamera.Follow = transform;
        }
    }
}
