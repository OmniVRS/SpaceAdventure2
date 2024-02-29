using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GadgetPickupable : MonoBehaviour, IPickable
{
    public GadgetScriptable gadgetScriptableObject;

    public void PickupItem()
    {
        Destroy(gameObject);
    }
}
