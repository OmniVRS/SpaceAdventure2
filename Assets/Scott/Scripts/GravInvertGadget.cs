using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravInvertGadget : MonoBehaviour
{
    private Rigidbody2D rb;
    private bool flipped = false;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            GetComponentInParent<GroundMovement>().canJump = false;
            if (!flipped)
            {
                flipped = true;
                rb.gravityScale *= -1;
                GetComponentInChildren<SpriteRenderer>().flipY = true;
            }

            else if (flipped)
            {
                flipped = false;
                rb.gravityScale *= -1;
                GetComponentInChildren<SpriteRenderer>().flipX = false;
            }
        }
    }
}
