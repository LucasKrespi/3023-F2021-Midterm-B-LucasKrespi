using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(GridLayout))]
public class PlayerGridInventory : MonoBehaviour
{
   
    [SerializeField]
    GameObject itemSlotPrefab;

    [SerializeField]
    Vector2Int GridDimensions = new Vector2Int(6, 6);

    private PlayerInventoryManager inventoryManager;

    void Start()
    {
        int numCells = GridDimensions.x * GridDimensions.y;

        inventoryManager = FindObjectOfType<PlayerInventoryManager>().GetInstance();

        while (transform.childCount < numCells)
        {
            GameObject newObject = Instantiate(itemSlotPrefab, this.transform);

            inventoryManager.itemSlots.Add(newObject);
        }
    }
    
}
