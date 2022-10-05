using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int index, level;
    public bool isMines;
    public UnitUIScript u;
    public CameraMovementScript cam;

    public void Start()
    {
        cam = Camera.main.GetComponent<CameraMovementScript>();
    }

    public void Update()
    {
        if(cam.currentpos == 0)
        {
            isMines = true;
        }
        else
        {
            isMines = false;
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        if(!isMines)
        {
            u.UnitPreviewCheck(true, index);
        }
        else
        {
            u.MinesPreviewCheck(true, index, level);
        }
        
       
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        if (!isMines)
        {
            u.UnitPreviewCheck(false, index);
        }
        else
        {
            u.MinesPreviewCheck(false, index, level);
        }
    }
}
