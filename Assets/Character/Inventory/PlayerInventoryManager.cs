using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    private PlayerInventoryManager Instance;

    public List<ItemSlot> itemSlots;

    [SerializeField]
    GameObject itemSlotPrefab;

    [SerializeField]
    Vector2Int GridDimensions = new Vector2Int(6, 6);

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }
    private void Start()
    {
        int numCells = GridDimensions.x * GridDimensions.y;

        while (transform.childCount < numCells)
        {
           GameObject newObject = Instantiate(itemSlotPrefab, this.transform);
           itemSlots.Add(newObject.GetComponent<ItemSlot>());
        }
    }

    public PlayerInventoryManager GetInstance()
    {
        return Instance;
    }

    public bool FindFreeSlot(Item itemAdded)
    {

        Debug.Log(itemSlots.Count);

        switch (itemAdded.name)
        {
            case "Sword":
                Debug.Log(itemAdded.name);

                for(int i = 0; i < itemSlots.Count; i++)
                {
                    if (itemSlots[i].itemInSlot != null)
                    {
                        if (itemSlots[i].itemInSlot.name == itemAdded.name)
                        {
                            itemSlots[i].ItemCount++;
                            itemSlots[i + GridDimensions.x].ItemCount++;

                            itemSlots[i].itemInSlot = itemAdded;

                            itemSlots[i].RefreshInfo();

                            return true;
                        }
                    }
                    else if (itemSlots[i].ItemCount == 0 && itemSlots[i + GridDimensions.x].ItemCount == 0)
                    {
                        itemSlots[i].ItemCount++;
                        itemSlots[i + GridDimensions.x].ItemCount++;

                        itemSlots[i].itemInSlot = itemAdded;

                        itemSlots[i].RefreshInfo();

                        return true;
                    }
                }
                break;
            case "Spear":
                for (int i = 0; i < itemSlots.Count; i++)
                {
                    if (itemSlots[i].itemInSlot != null)
                    {
                        if (itemSlots[i].itemInSlot.name == itemAdded.name)
                        {
                            itemSlots[i].ItemCount++;
                            itemSlots[i + GridDimensions.x].ItemCount++;
                            itemSlots[i + GridDimensions.x + GridDimensions.x].ItemCount++;

                            itemSlots[i].itemInSlot = itemAdded;

                            itemSlots[i].RefreshInfo();

                            return true;
                        }
                    }
                    else if (itemSlots[i].ItemCount == 0 && itemSlots[i + GridDimensions.x].ItemCount == 0 && itemSlots[i + GridDimensions.x + GridDimensions.x].ItemCount == 0)
                    {
                        itemSlots[i].ItemCount++;
                        itemSlots[i + GridDimensions.x].ItemCount++;
                        itemSlots[i + GridDimensions.x + GridDimensions.x].ItemCount++;

                        itemSlots[i].itemInSlot = itemAdded;

                        itemSlots[i].RefreshInfo();

                        return true;
                    }
                };
                break;
            case "Round Potion":
                for (int i = 0; i < itemSlots.Count; i++)
                {
                    if (itemSlots[i].itemInSlot != null)
                    {
                        if (itemSlots[i].itemInSlot.name == itemAdded.name)
                        {
                            itemSlots[i].ItemCount++;
                            itemSlots[i + GridDimensions.x].ItemCount++;
                            itemSlots[i + 1].ItemCount++;
                            itemSlots[i + 1 + GridDimensions.x].ItemCount++;


                            itemSlots[i].itemInSlot = itemAdded;

                            itemSlots[i].RefreshInfo();

                            return true;
                        }
                    }
                    else if (itemSlots[i].ItemCount == 0 && itemSlots[i + GridDimensions.x].ItemCount == 0 && itemSlots[i + 1].ItemCount == 0 && itemSlots[i + 1 + GridDimensions.x].ItemCount == 0)
                    {
                        itemSlots[i].ItemCount++;
                        itemSlots[i + GridDimensions.x].ItemCount++;
                        itemSlots[i + 1].ItemCount++;
                        itemSlots[i + 1 + GridDimensions.x].ItemCount++;


                        itemSlots[i].itemInSlot = itemAdded;

                        itemSlots[i].RefreshInfo();

                        return true;
                    }
                   
                }
                
                break;
        }







        //foreach (GameObject s in itemSlots)
        //{
        //    if(s.GetComponent<ItemSlot>().itemInSlot != null) 
        //    {
        //        if(s.GetComponent<ItemSlot>().itemInSlot.name == itemAdded.name)
        //        {
        //            return s;
        //        }
        //    }
        //    else if (s.GetComponent<ItemSlot>().ItemCount == 0)
        //    {
        //        return s;
        //    }
        //}


        return false;
    }


}
