using System.Linq;
using UnityEngine;

public class BuildingSystem : MonoBehaviour
{
    [Header("Variable")]
    public bool isBuilding = true;
    public GameObject buildObject;

    [Header("Class")]
    SetOverlay setOverlay;
    UIDisplay uIDisplay;

    void Awake() 
    {
        setOverlay = FindObjectOfType<SetOverlay>();
        uIDisplay = FindObjectOfType<UIDisplay>();
    }
    void LateUpdate()
    {
        if(isBuilding)
        {
            var focusedTileHit =  GetFocusedOnTile();
            if(focusedTileHit.HasValue)
            {
                GameObject groundTile = focusedTileHit.Value.collider.gameObject;
                buildObject.transform.position = groundTile.transform.position;
                if(Input.GetMouseButtonDown(0) && CheckCollision())
                {
                    StopBuilding();
                }
                else if(Input.GetMouseButtonDown(0) && !CheckCollision())
                {
                    uIDisplay.Warning("You cant build there!");
                }
            }
        }
    }
    public RaycastHit2D? GetFocusedOnTile()
    {
        Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector2 mousePos2D = new Vector2(mousePos.x,mousePos.y);
        RaycastHit2D[] hits = Physics2D.RaycastAll(mousePos2D, Vector2.zero);
        if(hits.Length > 0)
        {
            return hits.OrderByDescending(i => i.collider.transform.position.z).First();
        }

        return null;
    }

    private bool CheckCollision()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(buildObject.transform.position, 0.01f); 
        foreach (Collider2D collider in colliders)
        {
            if(colliders.Length <= 2)
            {
                return true;
            }
        }
        return false;
    }

    public void StartBuilding()
    {
        gameObject.GetComponent<BuildingSystem>().enabled = true;
        setOverlay.SetOverlayActive(true);
        uIDisplay.SetPanelsActive(0,false);
        uIDisplay.SetPanelsActive(1,false);
        uIDisplay.SetPanelsActive(3,false);
        uIDisplay.SetPanelsActive(4,false);
        uIDisplay.SetPanelsActive(5,false);
        uIDisplay.SetButtonslActive(2,false);
        uIDisplay.SetButtonslActive(3,false);
        isBuilding = true;
    }

    public void StopBuilding()
    {
        setOverlay.SetOverlayActive(false);
        uIDisplay.SetPanelsActive(1,true);
        uIDisplay.SetPanelsActive(3,true);
        uIDisplay.SetPanelsActive(4,false);
        uIDisplay.SetPanelsActive(5,false);
        uIDisplay.SetButtonslActive(2,true);
        uIDisplay.SetButtonslActive(3,true);
        uIDisplay.SetStatsInfoes();
        uIDisplay.SetEnergy();
        isBuilding = false; 
        gameObject.GetComponent<BuildingSystem>().enabled = false;
    }
}
