using UnityEngine;
using UnityEngine.EventSystems;

public class InteractObjects : MonoBehaviour
{
    [Header("Class")]
    BuildingSystem buildingSystem;
    UIDisplay uIDisplay;

    [Header("Variable")]
    public GameObject selectedGameObecjet;
 
    private void Start() 
    {
        uIDisplay = FindObjectOfType<UIDisplay>();
        buildingSystem = FindObjectOfType<BuildingSystem>();
    }
    void Update()
    {
        if(!buildingSystem.isBuilding)
        {
            InteractObject();
        }
    }

    public void InteractObject()
    {
        if(Input.GetMouseButtonDown(0) && !EventSystem.current.IsPointerOverGameObject())
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x,mousePos.y);
            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);

            if(hit.collider != null)
            {
                if(hit.collider.gameObject != selectedGameObecjet && selectedGameObecjet != null)
                {
                    selectedGameObecjet.GetComponent<SetMines>().isUIOpen = false;
                }

                if(hit.collider.gameObject.tag == "Minerals")
                {
                    selectedGameObecjet = hit.collider.gameObject;
                    selectedGameObecjet.GetComponent<SetMines>().isUIOpen = true;
                    uIDisplay.SetPanelsActive(0,true);
                }
                else
                {
                    uIDisplay.SetPanelsActive(0,false);
                }

            }
            else
            {
                uIDisplay.SetPanelsActive(0,false);
            }
        }
    }
}
