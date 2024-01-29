using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class MinesManager : MonoBehaviour
{
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

     [Header("Class")]
    [SerializeField] InventoryManager inventoryManager;
    private void Update() 
    {
        CheckDiscovered();
    }
    public void CalculateTotalAmount()
    {
        greenMine = (int)(greenMines[0].gameObject.GetComponent<SetMines>().collected 
        + greenMines[1].gameObject.GetComponent<SetMines>().collected 
        + greenMines[2].gameObject.GetComponent<SetMines>().collected);
        blueMine = (int)(blueMines[0].gameObject.GetComponent<SetMines>().collected 
        + blueMines[1].gameObject.GetComponent<SetMines>().collected);
        redMine = (int)purpleMines[0].gameObject.GetComponent<SetMines>().collected ;
        purpleMine = (int)redMines[0].gameObject.GetComponent<SetMines>().collected ;
    }

    public void CheckDiscovered()
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
            inventoryManager.inventoryUIs[3].titleText.text = purpleMine.ToString();
            inventoryManager.inventoryUIs[3].titleText.text = purpleMines[0].name;
            inventoryManager.inventoryUIs[3].image.sprite = purpleMines[0].GetComponent<SpriteRenderer>().sprite;
        }
    }

    public void SetMinesActive(bool set)
    {
        foreach (var item in greenMines)
        {
            if(!item.gameObject.GetComponent<SetMines>().isUnlock)
            item.gameObject.GetComponent<SetMines>().enabled = set;
        }
        foreach (var item in blueMines)
        {
            if(!item.gameObject.GetComponent<SetMines>().isUnlock)
            item.gameObject.GetComponent<SetMines>().enabled = set;
        }
        foreach (var item in purpleMines)
        {
            if(!item.gameObject.GetComponent<SetMines>().isUnlock)
            item.gameObject.GetComponent<SetMines>().enabled = set;
        }
        foreach (var item in redMines)
        {
            if(!item.gameObject.GetComponent<SetMines>().isUnlock)
            item.gameObject.GetComponent<SetMines>().enabled = set;
        }
    }
}
