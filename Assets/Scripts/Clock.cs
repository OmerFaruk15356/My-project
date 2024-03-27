using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class Clock : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] RectTransform hourHand; 
    const int hourTime = 13;
    float dayDuration = 260f;
    float totalTime = 0f;
    float currentTime = 0f;
    float hourToDegree = 360 / 12;

    [Header("Class")]
    Stats stats;
    UIDisplay uIDisplay;
    BuildingSystem buildingSystem;

    void Awake() 
    {
        stats = FindObjectOfType<Stats>();
        uIDisplay = FindObjectOfType<UIDisplay>();
        buildingSystem = FindObjectOfType<BuildingSystem>();
    }

    void Update() 
    {
        if(!buildingSystem.isBuilding)
        {
            totalTime += Time.deltaTime;
            currentTime = totalTime % dayDuration;
            var hour = currentTime * hourTime / dayDuration;
            hourHand.rotation = Quaternion.Euler(0,0, -hour * hourToDegree);
            if(hour >= 12)
            {
                totalTime = 0;
                currentTime = 0;
                stats.day++;
                uIDisplay.SetStatsInfoes();
            }
        }
    }
}
