using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Oven : MonoBehaviour
{
   MinesManager minesManager;


   private void Start() 
   {
        minesManager = FindObjectOfType<MinesManager>();
   }

   public void GetOre()
   {
        
   }
}
