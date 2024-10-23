using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OreRefinerList : MonoBehaviour
{
    [SerializeField] OreManager oreManager;
    [SerializeField] OreRefiner oreRefiner;
    [SerializeField] UIDisplay uIDisplay;
    [SerializeField] List <OreRefinerUI> oreRefinerUIs;
    [SerializeField] List <InventoryUI> inventoryUIs;
    [SerializeField] List <Sprite> oreSprites;
    [SerializeField] TextMeshProUGUI oreText1,oreText2,oreText3;
    [SerializeField] Button button1,button2;
    [SerializeField] Sprite defaultSprite;
    int mineIndex = -1,convertIndex;
    int converted;
    float duration = 6f;
    private void Update() {
        if(oreRefiner.isRefining)
        button1.GetComponentInChildren<TextMeshProUGUI>().text = inventoryUIs[mineIndex].descriptionText.text + '/' + 10;
        if(oreRefiner.isConverting)
        {
            duration -= (1 * Time.deltaTime);
            oreText3.text = Mathf.FloorToInt(duration).ToString();
        }
    }
    public void SetOreRefinerUI()
    {
        int number;
        for (int i = 0; i < oreRefinerUIs.Count; i++)
        {
            if(int.TryParse(inventoryUIs[i].descriptionText.text, out number))
            {
                oreRefinerUIs[i].gameObject.SetActive(true);
                oreRefinerUIs[i].image.sprite = inventoryUIs[i].image.sprite;
            }
        }
    }
    public void SelectOre(int index)
    {
        if((!oreRefiner.isConverting && oreRefiner.isFinished) || (index == mineIndex))
        {
            mineIndex = index;
            oreText1.gameObject.SetActive(true);
            button1.image.sprite = inventoryUIs[mineIndex].image.sprite;
            oreRefiner.enabled = true;
            oreRefiner.oreIndex = mineIndex;
            oreRefiner.isRefining = true;
            oreRefiner.isFinished = false;
        }
        else
        {
            uIDisplay.Warning("Please wait for the process to finish before converting to another");
        }
    }
    public void DeselectOre()
    {
        oreText1.gameObject.SetActive(false);
        button1.image.sprite = defaultSprite;
        oreRefiner.isRefining = false;
        oreRefiner.enabled = false;
    }
    public IEnumerator Converted()
    {
        yield return new WaitForSeconds(duration - 1);
        button2.image.sprite = oreSprites[mineIndex];
        converted++;
        oreText2.text = converted.ToString();
        oreRefiner.isConverting = false;
        oreText3.text = "";
        duration = 6;
    }
    public void FinishConvert()
    {
        if(oreText2.text != "")
        {
            oreManager.SetOreAmount(mineIndex,int.Parse(oreText2.text));
            button2.image.sprite = defaultSprite;
            converted = 0;
            oreText2.text = "";
            oreRefiner.isFinished = true;
        }
    }


}
