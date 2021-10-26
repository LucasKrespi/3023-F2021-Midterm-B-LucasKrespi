using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInventoryManager : MonoBehaviour
{
    private PlayerInventoryManager Instance;

   

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
        
    }

    private void Update()
    {
        
    }
    public PlayerInventoryManager GetInstance()
    {
        return Instance;
    }

   

}
