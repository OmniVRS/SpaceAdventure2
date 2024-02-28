using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GravInvertGadget : MonoBehaviour
{
    private Rigidbody2D rb;
    public bool flipped = false;

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
                // Rotate the player's transform to 180 degrees on the z-axis
                transform.Rotate(180, 0, 0);
            }
            else
            {
                flipped = false;
                rb.gravityScale *= -1;
                // Rotate the player's transform to 0 degrees on the z-axis
                transform.Rotate(-180, 0, 0);
            }
        }
    }
}
