using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventory : MonoBehaviour
{
    [Header("General")]
    public List<itemType> inventoryList;
    public int selectedItem;
    public CircleCollider2D playerReach;

    [Header("Keys")]
    [SerializeField] KeyCode pickItemKey;
    private bool isPickItemKeyPressed = false;

    [Header("Item gameobjects")]
    [SerializeField] GameObject gravSwitch;
    [SerializeField] GameObject personalTractorBeam;
    [SerializeField] GameObject radar;

    [Header("UI")]
    [SerializeField] Image[] inventorySoltImage = new Image[3];
    public bool[] isactive = new bool[3]; 
    [SerializeField] Image[] inventoryBackgroundImage = new Image[3];
    [SerializeField] Sprite emptySlotSprite;


    private Dictionary<itemType, GameObject> itemSetActive = new Dictionary<itemType, GameObject>();

    private void Start()
    {
        itemSetActive.Add(itemType.GravSwitch, gravSwitch);
        itemSetActive.Add(itemType.PersonalTractorBeam, personalTractorBeam);
        itemSetActive.Add(itemType.Radar, radar);

        GadgetSetActive();
    }


    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < 3; i++)
        {
            if (i < inventoryList.Count)
            {
                    inventorySoltImage[i].sprite = itemSetActive[inventoryList[i]].GetComponent<Gadget>().gadgetScriptableObject.gadgetSprite;

            }
            else
            {
                    inventorySoltImage[i].sprite = emptySlotSprite;
            }
            
        }

        int a = 0;
        foreach( Image image in inventoryBackgroundImage) 
        {
            if(a == selectedItem)
            {
                if (isactive[a])
                {
                    image.color = new Color32(145, 255, 126, 255);
                }
                else
                {
                    image.color = new Color32(219, 219, 219, 255);
                }
            }
            a++;
        }



        isPickItemKeyPressed = Input.GetKey(pickItemKey);
        if (Input.GetKeyDown(KeyCode.Alpha1) && inventoryList.Count > 0) 
        {
            selectedItem = 0;
            SetUiActive(selectedItem);
            GadgetSetActive();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha2) && inventoryList.Count > 1)
        {
            selectedItem = 1;
            SetUiActive(selectedItem);
            GadgetSetActive();
        }
        else if (Input.GetKeyDown(KeyCode.Alpha3) && inventoryList.Count > 2)
        {
            selectedItem = 2;
            SetUiActive(selectedItem);
            GadgetSetActive();
        }
    }

    private void SetUiActive(int uiSlot)
    {
        if (!isactive[uiSlot])
        {
            isactive[uiSlot] = true;
        }
        else { isactive[uiSlot] = false;}
    }
    private void GadgetSetActive()
    {
        if(inventoryList.Count > 0)
        {
            GameObject selectedItemGameObject = itemSetActive[inventoryList[selectedItem]];
            selectedItemGameObject.SetActive(true);
        }
    }
    private void OnTriggerStay2D(Collider2D collision)
    {
        Debug.Log(collision.gameObject.name);

        if (isPickItemKeyPressed)
        {

            GameObject otherGameObject = collision.gameObject;

            if (otherGameObject.CompareTag("Gadget"))
            {
                IPickable item = otherGameObject.GetComponent<IPickable>();

                if (item != null)
                {
                    inventoryList.Add(otherGameObject.GetComponent<GadgetPickupable>().gadgetScriptableObject.item_type);
                    item.PickupItem();
                }
            }
        }
    }
}
public interface IPickable
{
    void PickupItem();
}
