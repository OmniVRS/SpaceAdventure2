using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundMovement : MonoBehaviour
{
    private float horizontalInput;
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;
    private Animator animator;
    public GameObject tractorBeam;
    private bool isOn = false;
    public bool canJump = true;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        tractorBeam.SetActive(false);
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        transform.Translate(Vector2.right * horizontalInput * moveSpeed * Time.deltaTime, Space.World);

        float currentZRotation = transform.rotation.eulerAngles.z;

        // Only rotate when there is non-zero horizontal input
        if (horizontalInput != 0)
        {
            // Determine rotation based on horizontalInput and GravInvertGadget's flipped state
            float rotationY = horizontalInput > 0 ? 0 : 180;
            if (GetComponent<GravInvertGadget>().flipped)
            {
                // If flipped is true, reverse the rotationY value
                rotationY = (rotationY == 0) ? 180 : 0;
            }

            // Apply rotation, preserving the current z rotation
            transform.rotation = Quaternion.Euler(0, rotationY, currentZRotation);
        }
        else
        {
            // If not moving horizontally, maintain the current rotation
            // This prevents automatic rotation when stationary
            transform.rotation = Quaternion.Euler(0, transform.rotation.eulerAngles.y, currentZRotation);
        }

        if ((Input.GetKeyDown(KeyCode.Space) || Input.GetKeyDown(KeyCode.W) || Input.GetKeyDown(KeyCode.UpArrow)) && canJump)
        {
            canJump = false;

            if (GetComponent<GravInvertGadget>().flipped)
            {
                animator.SetTrigger("OnJump");
                rb.AddForce(Vector2.down * jumpForce, ForceMode2D.Impulse);
            }
            else
            {
                animator.SetTrigger("OnJump");
                rb.AddForce(Vector2.up * jumpForce, ForceMode2D.Impulse);
            }
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

        animator.SetFloat("Horizontal Input", Mathf.Abs(horizontalInput));
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Terrain"))
        {
            canJump = true;
        }
    }
}
