using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    [Header("List of Variable")]
    public List<ShopitemUI> shopitemUI;
    public List<ShopItemScriptableObjects> shopItemSO;

    [Header("Class")]
    Stats stats;
    ButtosAction buttosAction;

    [Header("Variable")]
    public int cost;
    public int xp;

    private void Start() 
    {
        stats = FindObjectOfType<Stats>();
        buttosAction = FindObjectOfType<ButtosAction>();
        for(int i = 0 ; i < shopItemSO.Count ; i++)
            shopitemUI[i].gameObject.SetActive(true);
        LoadPanel();
    }
    public void LoadPanel()
    {
        for(int i = 0 ; i < shopItemSO.Count ; i++)
        {
            shopitemUI[i].titleText.text = shopItemSO[i].GetTitle();
            shopitemUI[i].descriptionText.text = shopItemSO[i].GetDescription();
            shopitemUI[i].image.sprite = shopItemSO[i].GetItemImage();
            shopitemUI[i].costText.text = "Cost " + shopItemSO[i].GetCost().ToString() + "$";
        }
    }
    public void CheckShopping(int index)
    {
        if(stats.money >= shopItemSO[index].GetCost())
        {
            cost = shopItemSO[index].GetCost();
            xp = shopItemSO[index].GetXp();
            buttosAction.CanPurchase(true,shopItemSO[index].GetObject());
        }
        else
        {
            buttosAction.CanPurchase(false,shopItemSO[index].GetObject());
        }
    }
    
}
