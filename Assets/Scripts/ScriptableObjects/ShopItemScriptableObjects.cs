using System.Collections;
using System.Collections.Generic;
using Microsoft.Unity.VisualStudio.Editor;
using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/ItemsInfo")]
public class ShopItemScriptableObjects : ScriptableObject
{
    [Header("Variable")]
    [SerializeField] string title;
    [SerializeField] string description;
    [SerializeField] Sprite imageItem;
    [SerializeField] int cost;
    [SerializeField] int xp;
    [SerializeField] GameObject gameObj;

    public string GetTitle()
    {
        return this.title;
    }
    public string GetDescription()
    {
        return this.description;
    }
    public Sprite GetItemImage()
    {
        return this.imageItem;
    }
    public int GetCost()
    {
        return this.cost;
    }
    public int GetXp()
    {
        return xp;
    }
    public GameObject GetObject()
    {
        return gameObj;
    }
}
