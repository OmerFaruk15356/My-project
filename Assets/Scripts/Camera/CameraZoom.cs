using UnityEngine;

public class CameraZoom : MonoBehaviour
{
    [Header("Variable")]
    [SerializeField] float zoomSpeed;
    [SerializeField] float smoothChange;
    [SerializeField] float maxSize,minSize;
    bool canUpdate;

    [Header("Class")]
    Camera cam;

    void Start() 
    {
        cam = GetComponent<Camera>();
        canUpdate = false;
        Invoke("EnableUpdate", 1f);
    }

    void EnableUpdate()
    {
        canUpdate = true;
    }

    private void LateUpdate() 
    {
        if (!canUpdate) return;
        
        if(Input.mouseScrollDelta.y > 0)
        {
            if(cam.orthographicSize < minSize){return;}
            cam.orthographicSize -= zoomSpeed * Time.deltaTime * smoothChange;
        }
        if(Input.mouseScrollDelta.y < 0)
        {
            if(cam.orthographicSize > maxSize){return;}
            cam.orthographicSize += zoomSpeed * Time.deltaTime * smoothChange;
        }
    }
}
