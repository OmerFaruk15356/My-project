using UnityEngine;
public class Stats : MonoBehaviour
{
    [Header("Variable")]
    public int money = 100;
    public int xp = 0;
    public int xpForLevel = 100;
    public int day = 0;
    public int level = 0;
    public float energy = 100;

    public void BuyAction(int cost)
    {
        money -= cost;
    }

    public void SellAction(int earn)
    {
        money += earn;
    }

    public void SetXp(int getXp)
    {
        if((xp + getXp) >= xpForLevel)
        {
            level++;
            xp = (xp + getXp) - xpForLevel;
            xpForLevel *= 2;
        }
        else
        {
            xp += getXp;
        }
    }
}
