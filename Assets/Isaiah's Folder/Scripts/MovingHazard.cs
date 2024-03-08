using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingHazard : MonoBehaviour
{

    public Vector2 startingPosition;
    public float newX;
    public float newY;

    public bool isMovingVertically;
    public bool isMovingHorizontally;

    public float xAmp;
    public float yAmp;
    public float xPeriod = 1;
    public float yPeriod = 1;

    public bool usingXCos;
    public bool usingYCos;

    // Start is called before the first frame update
    void Start()
    {
        startingPosition = transform.position;
        newX = startingPosition.x;
        newY = startingPosition.y;
    }

    // Update is called once per frame
    void Update()
    {

        //Horizotal Movment
        if (isMovingHorizontally)
        {
            if (!usingXCos)
            {
                newX = startingPosition.x + (xAmp * Mathf.Sin((6.28f / xPeriod) * Time.time));
            }
            else
            {
                newX = startingPosition.x + (xAmp * Mathf.Cos((6.28f / xPeriod) * Time.time));
            }


        }
        //Vertical Movment
        if (isMovingVertically)
        {
            Debug.Log("vert");

            if (!usingYCos)
            {
                newY = startingPosition.y + (yAmp * Mathf.Sin((6.28f / yPeriod) * Time.time));
            }
            else
            {
                newY = startingPosition.y + (yAmp * Mathf.Cos((6.28f / yPeriod) * Time.time));
            }

        }

        //Update the position
        transform.position = new Vector2(newX, newY);
    }
}


