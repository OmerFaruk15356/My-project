using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OreManager : MonoBehaviour
{
    [SerializeField] InventoryManager inventoryManager;
    [SerializeField] List<Sprite> oreSprites;
    public int[] ores = {0,0,0,0};
    public bool[] isUnlock = {false,false,false,false};

    private void Update() 
    {
        if(inventoryManager.isSwitched)
        SetOreInventory();
    }
    public void SetOreAmount(int index,int amount)
    {
        ores[index] += amount;
        isUnlock[index] = true;
    }
    public void SetOreInventory()
    {
        if(isUnlock[0] == true )
        {
            inventoryManager.inventoryUIs[0].descriptionText.text = ores[0].ToString();
            inventoryManager.inventoryUIs[0].titleText.text = "Green Ore";
            inventoryManager.inventoryUIs[0].image.sprite = oreSprites[0];
        }
        if(isUnlock[1] == true)
        {
            inventoryManager.inventoryUIs[1].descriptionText.text = ores[1].ToString();
            inventoryManager.inventoryUIs[1].titleText.text = "Blue Ore";
            inventoryManager.inventoryUIs[1].image.sprite = oreSprites[1];
        }
        if(isUnlock[2] == true)
        {
            inventoryManager.inventoryUIs[2].descriptionText.text = ores[2].ToString();
            inventoryManager.inventoryUIs[2].titleText.text = "Red Ore";
            inventoryManager.inventoryUIs[2].image.sprite = oreSprites[2];
        }
        if(isUnlock[3] == true)
        {
            inventoryManager.inventoryUIs[3].descriptionText.text = ores[3].ToString();
            inventoryManager.inventoryUIs[3].titleText.text = "Purple Ore";
            inventoryManager.inventoryUIs[3].image.sprite = oreSprites[3];
        }
    }
}
