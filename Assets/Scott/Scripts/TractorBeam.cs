using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TractorBeam : MonoBehaviour
{
    
    public GameObject holdPoint;
    public GameObject heldItem;

    // Start is called before the first frame update
    void Start()
    {
        gameObject.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            holdPoint.transform.DetachChildren();
            heldItem = null;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            heldItem = collision.gameObject;
            collision.gameObject.transform.parent = holdPoint.transform;
            collision.gameObject.transform.position = new Vector2(holdPoint.transform.position.x, holdPoint.transform.position.y);
            collision.gameObject.transform.rotation = holdPoint.transform.rotation;
        }
    }
}
