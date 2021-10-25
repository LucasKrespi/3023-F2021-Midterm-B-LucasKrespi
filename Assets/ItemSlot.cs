using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Display item in the slot, update image, make clickable when there is an item, invisible when there is not
public class ItemSlot : MonoBehaviour
{
    public Item itemInSlot = null;
    private PlayerInventoryManager inventoryManager;

    [SerializeField]
    private int itemCount = 0;
    public int ItemCount
    {
        get
        {
            return itemCount;
        }
        set
        {
            itemCount = value;
        }
    }

    [SerializeField]
    private Button icon;
    [SerializeField]
    private TMPro.TextMeshProUGUI itemCountText;

    void Start()
    {
        RefreshInfo();
        inventoryManager = FindObjectOfType<PlayerInventoryManager>();
    }

    public void UseItemInSlot()
    {
        if(itemInSlot != null)
        {
            itemInSlot.Use();
            if (itemInSlot.isConsumable)
            {
                itemCount--;
                RefreshInfo();
            }
        }
    }

    public void AddItem()
    {
        
        if(this.itemInSlot != null)
        {
            if (inventoryManager.FindFreeSlot(itemInSlot))
            {
                itemCount--;
                RefreshInfo();
            }
            else
            {
                Debug.Log("Nos Space for " + itemInSlot.name);
            }
        }
    }

    public void RefreshInfo()
    {
        if(ItemCount < 1)
        {
            itemInSlot = null;
        }

        if(itemInSlot != null) // If an item is present
        {
            //update image and text
            itemCountText.text = ItemCount.ToString();
            icon.transform.localScale = new Vector3(itemInSlot.dimentionX, itemInSlot.dimentionY * 2, 0.0f);
            icon.image.sprite = itemInSlot.icon;
            icon.gameObject.SetActive(true);
        } 
        else
        {
            // No item
            itemCountText.text = "";
            icon.gameObject.SetActive(false);
        }
    }
}
