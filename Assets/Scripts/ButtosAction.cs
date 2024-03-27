using Unity.Mathematics;
using UnityEngine;

public class ButtosAction : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] GameObject buildObject,buildManager,shopItems;

    [Header("Class")]
    [SerializeField] ShopManager shopManager;
    InteractObjects interactObjects;
    Stats stats;
    UIDisplay uIDisplay;
    BuildingSystem buildingSystem;

    private void Start() 
    {
        buildingSystem = FindObjectOfType<BuildingSystem>();
        interactObjects = FindObjectOfType<InteractObjects>();
        stats = FindObjectOfType<Stats>();
        uIDisplay = FindObjectOfType<UIDisplay>();
    }
    public void CanUnlock(GameObject gameObj)
    {
        if(stats.money >= interactObjects.selectedGameObecjet.GetComponent<SetMines>().cost)
        {
            buildObject = gameObj;
            uIDisplay.SetConfirmUI();
            gameObject.name = "UnlockAction";
        }
        else
        {
            uIDisplay.Warning("You dont have enough money for this");
        }
    }
    public void CanUpgrade()
    {
        if(stats.money >= interactObjects.selectedGameObecjet.GetComponent<SetMines>().cost)
        {
            uIDisplay.SetConfirmUI();
            gameObject.name = "UpgradeAction";
        }
        else
        {
            uIDisplay.Warning("You dont have enough money for this");
        } 
    }
    public void CanPurchase(bool state,GameObject gameObj)
    {
        if(state)
        {
            buildObject = gameObj;
            uIDisplay.SetPanelsActive(5,false);
            uIDisplay.SetConfirmUI();
            gameObject.name = "PurchaseAction";
        }
        else
        {
            uIDisplay.SetPanelsActive(5,false);
            uIDisplay.Warning("You dont have enough money for this");
        }
    }
    public void AcceptAction()
    {
        if(gameObject.name == "UnlockAction")
        {
            stats.BuyAction(interactObjects.selectedGameObecjet.GetComponent<SetMines>().cost);
            stats.SetXp(interactObjects.selectedGameObecjet.GetComponent<SetMines>().xp);
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().isUnlock = true;
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().cost += 10;
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().xp += 10;
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().level++;
            var mineralExtractor = Instantiate(buildObject,new Vector3(interactObjects.selectedGameObecjet.transform.position.x,
            interactObjects.selectedGameObecjet.transform.position.y,
            interactObjects.selectedGameObecjet.transform.position.z + 1),quaternion.identity);
            mineralExtractor.transform.SetParent(interactObjects.selectedGameObecjet.transform);
            uIDisplay.SetStatsInfoes();
            uIDisplay.SetPanelsActive(2,false);
            gameObject.name = "NoAction";
        }
        if(gameObject.name == "UpgradeAction")
        {
            stats.BuyAction(interactObjects.selectedGameObecjet.GetComponent<SetMines>().cost);
            stats.SetXp(interactObjects.selectedGameObecjet.GetComponent<SetMines>().xp);
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().cost += 10;
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().xp += 10;
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().level++;
            interactObjects.selectedGameObecjet.GetComponent<SetMines>().mineRate += 0.25f;
            uIDisplay.SetStatsInfoes();   
            uIDisplay.SetPanelsActive(2,false);
            gameObject.name = "NoAction";
        }
        if(gameObject.name == "PurchaseAction")
        {
            uIDisplay.SetPanelsActive(5,false);
            GameObject newObject = Instantiate(buildObject,Vector3.zero,quaternion.identity);
            newObject.transform.SetParent(shopItems.transform);
            buildingSystem.buildObject = newObject;
            buildingSystem.StartBuilding();
            uIDisplay.SetStatsInfoes();
            uIDisplay.SetPanelsActive(2,false);
            stats.BuyAction(shopManager.cost);
            stats.SetXp(shopManager.xp);
            gameObject.name = "NoAction";
        }
    }
    public void DeclineAction()
    {
        uIDisplay.SetPanelsActive(2,false);
        gameObject.name = "NoAction";
    }
}
