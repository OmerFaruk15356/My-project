using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyConsumption : MonoBehaviour
{
    [Header("Vriable")]
    [SerializeField] float energyCost;

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
        if(stats.energy > 0)
        UsingEnergy();
    }

    public void UsingEnergy()
    {
        if(gameObject.GetComponent<BuildingSystem>() == null && !buildingSystem.isBuilding)
        stats.energy -= (energyCost * Time.deltaTime);
        uIDisplay.SetEnergy(); 
    }
}
