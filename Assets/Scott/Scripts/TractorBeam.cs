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
        if (Input.GetKeyDown(KeyCode.Alpha2) || Input.GetKeyDown(KeyCode.Space))
        {
            holdPoint.transform.DetachChildren();

            if (heldItem != null)
            {
                heldItem.GetComponent<Rigidbody2D>().isKinematic = false;
            }

            heldItem = null;
            gameObject.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Collectable"))
        {
            heldItem = collision.gameObject;
            collision.gameObject.transform.rotation = holdPoint.transform.rotation;
            heldItem.GetComponent<Rigidbody2D>().isKinematic = true;
            collision.gameObject.transform.parent = holdPoint.transform;
            collision.gameObject.transform.position = new Vector2(holdPoint.transform.position.x, holdPoint.transform.position.y);
        }
    }
}
