using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Plane draggingPlane;
    [SerializeField]
    private Vector3 offset;
    private Camera cam;

    private GameObject targetObject;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
    }


    private void OnMouseDown()
    {
        draggingPlane = new Plane(cam.transform.forward, targetObject.transform.position);
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        float planeDistance;
        draggingPlane.Raycast(camRay, out planeDistance);
        offset = targetObject.transform.position - camRay.GetPoint(planeDistance);

        Debug.DrawRay(cam.transform.forward, camRay.GetPoint(planeDistance));
    }

    private void OnMouseDrag()
    {
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
        float planeDistance;
        draggingPlane.Raycast(camRay, out planeDistance);
        targetObject.transform.position = camRay.GetPoint(planeDistance) + offset;
    }

    
}
