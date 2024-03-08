using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LockedObject : MonoBehaviour
{
    public GameObject whatOpensThis;
    private SpriteRenderer sr;
    public Sprite openedLock;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            GameObject playerItem = collision.gameObject.GetComponent<PlayerMovement>().tractorBeam.GetComponent<TractorBeam>().heldItem;
            if (playerItem == whatOpensThis)
            {
                Destroy(playerItem);
                StartCoroutine(OpenSaysMe());
            }
        }
    }

    IEnumerator OpenSaysMe()
    {
        sr.sprite = openedLock;
        yield return new WaitForSeconds(1.5f);
        Destroy(gameObject);
    }
}
