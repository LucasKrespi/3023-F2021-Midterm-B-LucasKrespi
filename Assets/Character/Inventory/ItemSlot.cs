using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

// Display item in the slot, update image, make clickable when there is an item, invisible when there is not
public class ItemSlot : MonoBehaviour
{
    public bool isOccupied = false;

    [SerializeField]
    private List<GameObject> collisionList;

    private void Update()
    {
        updateOccuoiedStatus();

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision != null)
        collisionList.Add(collision.gameObject);

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
         if(collision != null)
        collisionList.Remove(collision.gameObject);
    }

    public void updateOccuoiedStatus()
    {
        if (collisionList != null)
        { 
            if (collisionList.Count > 1)
            {
              isOccupied = true;
            }
            else
            {
               isOccupied = false;
            }
        }
    }
}

