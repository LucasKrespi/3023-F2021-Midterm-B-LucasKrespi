using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField]
    private Item item_scriptableObj;
    [SerializeField]
    private Image item_image;

    private int numOfSlots;
    public Vector3 initialPos;

    private bool isSelectec = false;
    [SerializeField]
    private bool isPlacable = false;

    public List<ItemSlot> collisionList;


    public GameObject container;
    public GameObject PlayerBag;

   
    // Start is called before the first frame update
    void Start()
    {
        initialPos = transform.position;

        if (item_scriptableObj != null)
        {
            item_image.sprite = item_scriptableObj.icon;
            this.transform.localScale = new Vector2(item_scriptableObj.dimentionX, item_scriptableObj.dimentionY) * 0.5f;
            numOfSlots = (item_scriptableObj.dimentionX * item_scriptableObj.dimentionY);
        }

        transform.SetParent(container.transform);
    }

    // Update is called once per frame
    void Update()
    {
        if (isSelectec)
        {
            transform.position = Input.mousePosition;
        }
      

        foreach (ItemSlot i in collisionList)
        {

            if (collisionList.Count == GetNumOfSlots() && !i.isOccupied)
            {
                i.GetComponent<Image>().color = Color.green;
                isPlacable = true;
            }
            else
            {
                i.GetComponent<Image>().color = Color.red;
                isPlacable = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            if(isSelectec)
                transform.rotation *= (Quaternion.Euler(0.0f, 0.0f, -90.0f));
        }

       
    }

    public void onClick()
    {
        isSelectec = !isSelectec;

       

        if (!isPlacable)
        {
            transform.position = initialPos;
            foreach (ItemSlot i in collisionList)
            {
                i.isOccupied = false;
            }
        }
        else
        {
           foreach(ItemSlot i in collisionList)
           {
                i.isOccupied = true;
           }
        }
    }

    public int GetNumOfSlots()
    {
        return numOfSlots;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        collisionList.Add(collision.gameObject.GetComponent<ItemSlot>());

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        collisionList.Remove(collision.gameObject.GetComponent<ItemSlot>());
        collision.gameObject.GetComponent<Image>().color = Color.white;
      
    }
}
