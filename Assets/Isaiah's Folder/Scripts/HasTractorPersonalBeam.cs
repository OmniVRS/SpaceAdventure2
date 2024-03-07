using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HasTractorPersonalBeam : MonoBehaviour
{
    public bool personalTractorBeam = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.GetComponent<Animator>().SetBool("HasPersonalTractorBeam", true);
            personalTractorBeam = true;
        }
    }

}
