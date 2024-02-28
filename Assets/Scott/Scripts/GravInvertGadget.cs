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
        
    }
}
