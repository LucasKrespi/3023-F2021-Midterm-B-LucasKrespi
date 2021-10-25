using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventoryManager : MonoBehaviour
{
    private PlayerInventoryManager Instance;

    public List<GameObject> itemSlots;
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

    public PlayerInventoryManager GetInstance()
    {
        return Instance;
    }

    public GameObject FindFreeSlot()
    {
        foreach(GameObject s in itemSlots)
        {
            if(s.GetComponent<ItemSlot>().ItemCount == 0)
            {
                return s;
            }
        }


        return null;
    }


}
