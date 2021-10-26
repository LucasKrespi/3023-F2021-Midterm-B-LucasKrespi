using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ItemBehavior : MonoBehaviour
{
    [SerializeField]
    private Item m_itemScriptableObj;
    [SerializeField]
    private Image m_itemImage;

    private int m_iNumOfSlots;

    private bool m_bIsSelectec = false;
    [SerializeField]
    private bool m_bIsPlacable = false;

    public List<ItemSlot> m_collisionList;
    public List<ItemSlot> m_myTiles;

    public GameObject m_gParent;
   
    // Start is called before the first frame update
    void Start()
    {
        //iniciate Item based on the scriptable object
        if (m_itemScriptableObj != null)
        {
            m_itemImage.sprite = m_itemScriptableObj.icon;
            this.transform.localScale = new Vector2(m_itemScriptableObj.dimentionX, m_itemScriptableObj.dimentionY) * 0.5f;
            m_iNumOfSlots = (m_itemScriptableObj.dimentionX * m_itemScriptableObj.dimentionY);
        }

    }

    // Update is called once per frame
    void Update()
    {
        if (m_bIsSelectec)
        {
            transform.position = Input.mousePosition;
        }
      

        foreach (ItemSlot i in m_collisionList)
        {

            if (m_collisionList.Count == GetNumOfSlots() && !i.isOccupied)
            {
                i.GetComponent<Image>().color = Color.green;
                m_bIsPlacable = true;
            }
            else
            {
                i.GetComponent<Image>().color = Color.red;
                m_bIsPlacable = false;
            }
        }


        if (Input.GetKeyDown(KeyCode.R))
        {
            if(m_bIsSelectec)
                transform.rotation *= (Quaternion.Euler(0.0f, 0.0f, -90.0f));
        }

    }
    public void onClick()
    {

        if (!m_bIsPlacable)
        {
            if (!m_bIsSelectec)
            {
                m_bIsSelectec = true;

                foreach (ItemSlot i in m_myTiles)
                {
                    i.isOccupied = false;
                }
            }

            //if Item is not placable and is not select it will keep the item on mouse pos. to drop item in an inventory it need to be placable
            //if (!m_bIsSelectec)
            //{
            //    m_bIsSelectec = true;
            //}
            //foreach (ItemSlot i in m_collisionList)
            //{
            //    if(m_myTiles.Contains(i))
            //        i.isOccupied = false;
            //}
        }
        else
        {
            if (m_bIsSelectec)
            {
                m_myTiles.Clear();

                foreach (ItemSlot i in m_collisionList)
                {
                  
                    i.isOccupied = true;
              
                }

                m_myTiles = new List<ItemSlot>(m_collisionList);
                m_bIsSelectec = false;

            }



           
       
        }
    }

    public int GetNumOfSlots()
    {
        return m_iNumOfSlots;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {

        m_collisionList.Add(collision.gameObject.GetComponent<ItemSlot>());

    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        m_collisionList.Remove(collision.gameObject.GetComponent<ItemSlot>());
        collision.gameObject.GetComponent<Image>().color = Color.white;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        m_bIsPlacable = false;
    }


}
