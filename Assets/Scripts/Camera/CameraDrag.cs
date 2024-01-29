using UnityEngine;

public class CameraDrag : MonoBehaviour
{
    [Header("Variable")]
    Vector3 origin;
    Vector3 differance;
    bool drag = false;
    void LateUpdate()
    {
        if(Input.GetMouseButton(1))
        {
            differance = (Camera.main.ScreenToWorldPoint(Input.mousePosition)) - Camera.main.transform.position;
            if(drag == false)
            {
                drag = true;
                origin = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            }
        }
        else
        {
            drag = false;
        }
        if(drag)
        {
            Camera.main.transform.position = origin - differance;
        }
    }
}
