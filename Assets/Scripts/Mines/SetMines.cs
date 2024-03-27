using System;
using UnityEngine;

public class SetMines : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] MineScriptable mineScriptable;
    public int level,cost,xp;
    public float mineRate,collected;
    public bool isUnlock,isUIOpen;

    [Header("Class")]
    UIDisplay uIDisplay;

    Stats stats;
    void Start() 
    {
        stats = FindObjectOfType<Stats>();
        uIDisplay = FindObjectOfType<UIDisplay>();
        gameObject.name = mineScriptable.GetMineName();
        level = mineScriptable.GetMineLevel();
        mineRate = mineScriptable.GetMineRate();
        isUnlock = mineScriptable.GetMineState();
        cost = mineScriptable.GetMineCost(); 
        xp = mineScriptable.GetMineXp();
    }

    private void Update() 
    {
        if(isUnlock)
        {
            StartMining();
        }
        if(isUIOpen)
        {
            SetMineInfoes();
        }
    }
    public void StartMining()
    {
        if(stats.energy > 0)
        collected += (mineRate * Time.deltaTime);
    }
    public void SetMineInfoes()
    {
        uIDisplay.DisplayInfoes(mineScriptable.GetMineName(),collected,
        level,mineRate,mineScriptable.GetMineIcon(),cost);
        uIDisplay.SetButtonslActive(0,!isUnlock);
        uIDisplay.SetButtonslActive(1,isUnlock);
    }
}
