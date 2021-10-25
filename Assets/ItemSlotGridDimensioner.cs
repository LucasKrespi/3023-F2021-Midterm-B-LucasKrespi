using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Instantiates prefabs to fill a grid
[RequireComponent(typeof(GridLayout))]
public class ItemSlotGridDimensioner : MonoBehaviour
{
    [SerializeField]
    GameObject itemSlotPrefab;
    [SerializeField]
    List<Item> items;

    [SerializeField]
    Vector2Int GridDimensions = new Vector2Int(6, 6);

    void Start()
    {
        int numCells = GridDimensions.x * GridDimensions.y;

        while (transform.childCount < numCells)
        {
            GameObject newObject = Instantiate(itemSlotPrefab, this.transform);
            
            newObject.GetComponent<ItemSlot>().ItemCount++;
            newObject.GetComponent<ItemSlot>().itemInSlot = items[transform.childCount % 3];
            newObject.GetComponent<ItemSlot>().RefreshInfo();
            
        }
    }
}
