using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public int index;
    public UnitUIScript u;

    public void OnPointerEnter(PointerEventData eventData)
    {
        u.PreviewCheck(true, index);
        Debug.Log("over button " + index);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        u.PreviewCheck(false, index);
    }
}
