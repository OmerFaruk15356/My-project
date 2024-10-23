using System;
using System.Collections;
using System.Collections.Generic;
using System.Data.SqlTypes;
using UnityEngine;

public class Selling : MonoBehaviour
{
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] Stats stats;
    [SerializeField] UIDisplay uIDisplay;
    List <int> valueOfTheSelling;
    int index;
    public void Sell(int itemIndex)
    {
        index = itemIndex;
        if(inventoryManager.CheckMine(index))
        {

        }
    }

    public void StartSelling()
    {
        
    }
}
