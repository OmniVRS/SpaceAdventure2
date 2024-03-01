using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScannerGadget : MonoBehaviour
{
    public bool scanOn;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ToggleScan();
        }
    }

    void ToggleScan()
    {
        scanOn = !scanOn; // Toggle scanOn flag

        GameObject[] secrets = GameObject.FindGameObjectsWithTag("Secret");

        foreach (GameObject secret in secrets)
        {
            SpriteRenderer secretRenderer = secret.GetComponent<SpriteRenderer>();
            if (secretRenderer != null)
            {
                Color color = secretRenderer.color;
                color.a = scanOn ? 0.5f : 0f; // Set alpha based on scanOn
                secretRenderer.color = color;
            }
            else
            {
                Debug.LogWarning("Secret GameObject is missing SpriteRenderer component.");
            }
        }
    }
}
