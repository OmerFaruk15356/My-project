using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("List of Variable")]
    public List<InventoryUI> inventoryUIs;
    public List<MineScriptable> mineScriptables;
    private void Start() 
    {
        LoadPanel();
    }

    public void LoadPanel()
    {
        for(int i = 0 ; i < mineScriptables.Count ; i++)
        {
            inventoryUIs[i].titleText.text = "Unknown";
            inventoryUIs[i].descriptionText.text = "Undiscovered";
        }
    }
}
