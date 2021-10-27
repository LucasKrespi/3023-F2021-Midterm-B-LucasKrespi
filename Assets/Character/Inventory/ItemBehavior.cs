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
    private bool m_bIsPlacable = false;

    public List<ItemSlot> m_collisionList;

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

            if (m_collisionList.Count == GetNumOfSlots() && isNotListOccupied())
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


        if (Input.GetKeyDown(KeyCode.Mouse1))
        {
            if(m_bIsSelectec)
                transform.rotation *= (Quaternion.Euler(0.0f, 0.0f, -90.0f));
        }

    }
    public void onClick()
    {
        if (m_bIsPlacable)
        {
            m_bIsSelectec = !m_bIsSelectec;
        }

        manageNotSelectedButtons();
    }

    private void manageNotSelectedButtons()
    {
        if (m_bIsSelectec)
        {
            foreach (GameObject go in FindObjectOfType<InventoryManager>().itensList)
            {
                if (go.name != this.name)
                {
                    go.GetComponent<Button>().enabled = false;
                }
            }
        }
        else
        {
            foreach (GameObject go in FindObjectOfType<InventoryManager>().itensList)
            {
                go.GetComponent<Button>().enabled = true;
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
    
    private bool isNotListOccupied()
    {
        foreach(ItemSlot i in m_collisionList)
        {
            if (i.isOccupied)
            {
                return false;
            }
        }

        return true;
    }

    public bool returnIsSelected()
    {
        return m_bIsSelectec;
    }
}
