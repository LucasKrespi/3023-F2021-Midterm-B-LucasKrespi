using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Display item in the slot, update image, make clickable when there is an item, invisible when there is not
public class ItemSlot : MonoBehaviour
{
    public Item itemInSlot = null;
    private PlayerInventoryManager inventoryManager;
    public bool isOccupied = false;




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

  
    void Start()
    {
        
        inventoryManager = FindObjectOfType<PlayerInventoryManager>();
    }

    public void UseItemInSlot()
    {
   
    }

    public void AddItem()
    {
        
    
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
       // isOccupied = false;
    }

}
