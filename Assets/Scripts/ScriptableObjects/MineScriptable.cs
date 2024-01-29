using UnityEngine;

[CreateAssetMenu(fileName = "ScriptableObject", menuName = "ScriptableObject/MinesInfo")]
public class MineScriptable : ScriptableObject
{
    [Header("Variable")]
    [SerializeField] int level;
    [SerializeField] int cost;
    [SerializeField] int xp;
    [SerializeField] float mineRate,collected;
    [SerializeField] string mineName;
    [SerializeField] Sprite icon;
    bool isUnlock;

    public string GetMineName()
    {
        return this.mineName;
    }

    public float GetMineRate()
    {
        return this.mineRate;
    }
    public float GetCollectedAmount()
    {
        return this.collected;
    }

    public int GetMineLevel()
    {
        return this.level;
    }

    public Sprite GetMineIcon()
    {
        return this.icon;
    }

    public bool GetMineState()
    {
        return this.isUnlock;
    }

    public int GetMineCost()
    {
        return this.cost;
    }
    public int GetMineXp()
    {
        return this.xp;
    }
}
