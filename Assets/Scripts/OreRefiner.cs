using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OreRefiner : MonoBehaviour
{
   [SerializeField] GameObject oreListPanel;
   [SerializeField] OreRefinerList oreRefinerList;
   [SerializeField] MinesManager minesManager;
   public int oreIndex;
   public bool isRefining,isConverting,isFinished = true;

   private void Update() 
   {
      if(isRefining && !isConverting)
      ConvertOre();
   }
   public void GetOre()
   {
      if(!isRefining)
      {
         oreListPanel.SetActive(true);
         oreRefinerList.SetOreRefinerUI();
      }
      else
      {
         oreRefinerList.DeselectOre();
      }
   }
   public void ConvertOre()
   {
      if(oreIndex == 0 && minesManager.greenMine >= 10)
      {
         isConverting = true;
         minesManager.greenMineConverted -= 10;
         StartCoroutine(oreRefinerList.Converted());
      }
      else if(oreIndex == 1 && minesManager.blueMine >= 10)
      {
         isConverting = true;
         minesManager.blueMineConverted -= 10;
         StartCoroutine(oreRefinerList.Converted());
      }
      else if(oreIndex == 2 && minesManager.redMine >= 10)
      {
         isConverting = true;
         minesManager.redMineConverted -= 10;
         StartCoroutine(oreRefinerList.Converted());
      }
      else if(oreIndex == 3 && minesManager.purpleMine >= 10)
      {
         isConverting = true;
         minesManager.purpleMineConverted -= 10;
         StartCoroutine(oreRefinerList.Converted());
      }
   }
}
