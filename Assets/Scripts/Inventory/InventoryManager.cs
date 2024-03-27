using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class InventoryManager : MonoBehaviour
{
    [Header("List of Variable")]
    public List<InventoryUI> inventoryUIs;
    [SerializeField] Sprite unknownSprite;
    public bool isSwitched;
    private void Start() {
        LoadPanel(false);
    }
    public void LoadPanel(bool state)
    {
        isSwitched = state;
        for(int i = 0 ; i < inventoryUIs.Count ; i++)
        {
            inventoryUIs[i].titleText.text = "Unknown";
            inventoryUIs[i].descriptionText.text = "Undiscovered";
            inventoryUIs[i].image.sprite = unknownSprite;
        }
    }
}
