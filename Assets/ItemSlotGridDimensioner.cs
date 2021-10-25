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
    Item Item01;
    [SerializeField]
    Item Item02;
    [SerializeField]
    Item Item03;

    [SerializeField]
    Vector2Int GridDimensions = new Vector2Int(6, 6);

    void Start()
    {
        int numCells = GridDimensions.x * GridDimensions.y;

        while (transform.childCount < numCells)
        {
            GameObject newObject = Instantiate(itemSlotPrefab, this.transform);

            if(Item01 != null)
            {
                newObject.GetComponent<ItemSlot>().ItemCount++;
                newObject.GetComponent<ItemSlot>().itemInSlot = Item01;
                newObject.GetComponent<ItemSlot>().RefreshInfo();
            }
        }
    }
}
