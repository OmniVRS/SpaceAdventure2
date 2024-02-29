using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerGadget : MonoBehaviour
{
    public bool scanOn;
    public GameObject[] secrets;

    // Start is called before the first frame update
    void Start()
    {
        scanOn = false;
        secrets = GameObject.FindGameObjectsWithTag("Secret");
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            foreach (GameObject secret in secrets)
            {
                if (!scanOn)
                {
                    scanOn = true;
                    SpriteRenderer secretsColor = secret.GetComponent<SpriteRenderer>();
                    secret.GetComponent<SpriteRenderer>().color = new Color(secretsColor.color.r, secretsColor.color.g, secretsColor.color.b, 0.5f);
                }
                else if (scanOn)
                {
                    scanOn = false;
                    SpriteRenderer secretsColor = secret.GetComponent<SpriteRenderer>();
                    secret.GetComponent<SpriteRenderer>().color = new Color(secretsColor.color.r, secretsColor.color.g, secretsColor.color.b, 0f);
                }
            }
        }
    }
}
