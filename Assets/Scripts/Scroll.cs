using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scroll : MonoBehaviour
{
    private Plane draggingPlane;
    [SerializeField]
    //private Vector3 offset;
    private Camera cam;

    public bool isFollowing;
    public bool canFollow;
    // Start is called before the first frame update
    void Start()
    {
        cam = Camera.main;
        canFollow = true;
    }


    private void OnMouseDown()
    {
        draggingPlane = new Plane(cam.transform.forward, gameObject.transform.position);
        Ray camRay = cam.ScreenPointToRay(Input.mousePosition);

        float planeDistance;
        draggingPlane.Raycast(camRay, out planeDistance);
        //offset = gameObject.transform.position - camRay.GetPoint(planeDistance);

        Debug.DrawRay(cam.transform.forward, camRay.GetPoint(planeDistance));
    }

    private void OnMouseDrag()
    {
        if (canFollow)
        {
            Ray camRay = cam.ScreenPointToRay(Input.mousePosition);
            float planeDistance;
            draggingPlane.Raycast(camRay, out planeDistance);
            transform.position = camRay.GetPoint(planeDistance); //+ offset;
            isFollowing = true;
        }
    }

    private void OnMouseUp()
    {
        isFollowing = false;
    }


}
