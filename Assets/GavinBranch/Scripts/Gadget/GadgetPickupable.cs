using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.VFX;

public class GadgetPickupable : MonoBehaviour, IPickable , IDataPersistence
{
    //give speical ids for gadgets
    [SerializeField] private string id;
    [ContextMenu("Generate guid for id")]
    private void GenerateGuid()
    {
        id = System.Guid.NewGuid().ToString();
    }
    private void Start()
    {
        PlayerInventory playerInventory = GameObject.Find("Player").GetComponent<PlayerInventory>();

        if (playerInventory != null && playerInventory.inventoryList.Contains(gadgetScriptableObject.item_type))
        {
            // The item is already in the player's inventory, call PickupItem method
            PickupItem();
        }
    }

    public GadgetScriptable gadgetScriptableObject;
    public bool isCollected = false;
    public void PickupItem()
    {
        gameObject.GetComponent<CircleCollider2D>().enabled = false;
        isCollected = true;
        gameObject.GetComponentInChildren<SpriteRenderer>().enabled = false;
    }
    public void LoadData(GameData data)
    {
        data.GadgetsCollected.TryGetValue(id, out isCollected);
        Debug.Log(isCollected);
        if(isCollected) 
        { 
            PickupItem();
            GameObject.Find("Player").GetComponent<PlayerInventory>().AddItemToInventory(this, this);
        }
    }
    public void SaveData(ref GameData data) 
    {
        if(data.GadgetsCollected.ContainsKey(id))
        {
            data.GadgetsCollected.Remove(id);
        }
        data.GadgetsCollected.Add(id, isCollected);
    }
}
