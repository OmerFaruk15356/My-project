using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] float energyProduct;

    [Header("Class")]
    Stats stats;
    BuildingSystem buildingSystem;
    UIDisplay uIDisplay;
    
    void Awake() 
    {
        stats = FindObjectOfType<Stats>();
        uIDisplay = FindObjectOfType<UIDisplay>();
        buildingSystem = FindObjectOfType<BuildingSystem>();
    }

    void Update() 
    {
        UsingEnergy();
    }

    public void UsingEnergy()
    {
        if(gameObject.GetComponent<BuildingSystem>() == null && !buildingSystem.isBuilding)
        stats.energy += (energyProduct * Time.deltaTime);
        uIDisplay.SetEnergy(); 
    }
}