using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinesManager : MonoBehaviour
{
    [Header("Class")]
    [SerializeField] InventoryManager inventoryManager;

    [Header("Lists")]
    [SerializeField] List<GameObject> greenMines;
    [SerializeField] List<GameObject> blueMines;
    [SerializeField] List<GameObject> purpleMines;
    [SerializeField] List<GameObject> redMines;

    [Header("MineVariable")]
    public float greenMine;
    public float blueMine;
    public float redMine;
    public float purpleMine;
    public float greenMineConverted;
    public float blueMineConverted;
    public float redMineConverted;
    public float purpleMineConverted;
    public float greenMineSelling;
    public float blueMineSelling;
    public float redMineSelling;
    public float purpleMineSelling;

    private void Update() 
    {
        if(!inventoryManager.isSwitched)
        SetMineInventory();
        CalculateTotalAmount();
    }
    public void CalculateTotalAmount()
    {
        greenMine = (int)(greenMines[0].gameObject.GetComponent<SetMines>().collected 
        + greenMines[1].gameObject.GetComponent<SetMines>().collected 
        + greenMines[2].gameObject.GetComponent<SetMines>().collected) + greenMineConverted + greenMineSelling;
        blueMine = (int)(blueMines[0].gameObject.GetComponent<SetMines>().collected 
        + blueMines[1].gameObject.GetComponent<SetMines>().collected) + blueMineConverted + blueMineSelling;
        redMine = (int)redMines[0].gameObject.GetComponent<SetMines>().collected + redMineConverted + redMineSelling;
        purpleMine = (int)purpleMines[0].gameObject.GetComponent<SetMines>().collected + purpleMineConverted + purpleMineSelling;
    }

    public void SetMineInventory()
    {
        if(greenMine > 0)
        {
            inventoryManager.inventoryUIs[0].descriptionText.text = greenMine.ToString();
            inventoryManager.inventoryUIs[0].titleText.text = greenMines[0].name;
            inventoryManager.inventoryUIs[0].image.sprite = greenMines[0].GetComponent<SpriteRenderer>().sprite;
        }
        if(blueMine > 0)
        {
            inventoryManager.inventoryUIs[1].descriptionText.text = blueMine.ToString();
            inventoryManager.inventoryUIs[1].titleText.text = blueMines[0].name;
            inventoryManager.inventoryUIs[1].image.sprite = blueMines[0].GetComponent<SpriteRenderer>().sprite;
        }
        if(redMine > 0)
        {
            inventoryManager.inventoryUIs[2].descriptionText.text = redMine.ToString();
            inventoryManager.inventoryUIs[2].titleText.text = redMines[0].name;
            inventoryManager.inventoryUIs[2].image.sprite = redMines[0].GetComponent<SpriteRenderer>().sprite;
        }
        if(purpleMine > 0)
        {
            inventoryManager.inventoryUIs[3].descriptionText.text = purpleMine.ToString();
            inventoryManager.inventoryUIs[3].titleText.text = purpleMines[0].name;
            inventoryManager.inventoryUIs[3].image.sprite = purpleMines[0].GetComponent<SpriteRenderer>().sprite;
        }
    }
}
