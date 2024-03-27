using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class UIDisplay : MonoBehaviour
{
    [Header("UIElement")]
    [SerializeField] List<GameObject> panels;
    [SerializeField] List<TextMeshProUGUI> texts;
    [SerializeField] List<Button> buttons;
    [SerializeField] Image image;
    [SerializeField] Slider slider;

    [Header("Class")]
    Stats stats;
    
    void Start() 
    {
        stats = FindObjectOfType<Stats>();
    }

    public void DisplayInfoes(string name, float collected,int level,float mineRate, Sprite icon, int cost)
    {
       image.sprite = icon;
       texts[0].text = "  " + name + "\t" + mineRate + "\t" + Mathf.FloorToInt(collected);
       texts[5].text = "\tLevel: " + level.ToString() + "\nCost to process " + cost + "$";
    }
    public void SetStatsInfoes()
    {
        slider.value = stats.xp;
        slider.maxValue = stats.xpForLevel;
        texts[1].text = "   " + stats.level + "\n" +
        "$" + stats.money + "\n" +
        " Day " + stats.day + "\n";
        texts[2].text = stats.xp + "/" + stats.xpForLevel;
    }
    public void SetConfirmUI()
    {
        SetPanelsActive(2,true);
        texts[3].text = "Do you confirm this action?";
    }
    public void Warning(string text)
    {
        texts[4].gameObject.SetActive(true);
        texts[4].text = text;
        StartCoroutine(SetTextInactiveAfterDelay(1.5f));
    }
    IEnumerator SetTextInactiveAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        texts[4].gameObject.SetActive(false);
    }
    public void SetPanelsActive(int id,bool set)
    {
        panels[id].SetActive(set);
    }
    public void SetButtonslActive(int id,bool set)
    {
        buttons[id].gameObject.SetActive(set);
    }
    public void SetEnergy()
    {
        texts[6].text = (int)stats.energy + "\n";
    }

    public void SetShopMoney()
    {
        texts[7].text = stats.money + "$";
    }
}
