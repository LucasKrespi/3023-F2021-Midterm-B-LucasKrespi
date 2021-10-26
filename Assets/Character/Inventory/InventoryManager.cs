using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class InventoryManager : MonoBehaviour
{
    private InventoryManager m_Instance;

    public GameObject container;
    public GameObject playerBag;

    public List<ItemSlot> ocupiedSlots;

    [SerializeField]
    private List<GameObject> itensList;

    private void Awake()
    {
        if(m_Instance == null)
        {
            m_Instance = this;
        }
        else
        {
            Destroy(this);
        }
    }

    private void Update()
    {

        foreach(GameObject go in itensList)
        {
            if(go.GetComponent<RectTransform>().localPosition.x > 0)
            {
                go.GetComponent<ItemBehavior>().m_gParent = container;
            }
            else
            {
                go.GetComponent<ItemBehavior>().m_gParent = playerBag;
            }

            if (go.GetComponent<ItemBehavior>().m_gParent.activeInHierarchy)
            {
                go.SetActive(true);
            }
            else
            {
                go.SetActive(false);
            }
        }
    }
    public InventoryManager GetInstance()
    {
        return m_Instance;
    }

}
