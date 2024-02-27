using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float horizontalInput;
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    public GameObject tractorBeam;
    private bool isOn = false;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tractorBeam.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime);

        if (horizontalInput > 0)
        {
            
        }

        if (horizontalInput < 0)
        {
            
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canJump)
        {
            canJump = false;
            rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            if (!isOn)
            {
                isOn = true;
                tractorBeam.gameObject.SetActive(true);
            }

            if (isOn)
            {
                isOn = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            canJump = true;
        }
    }
}
