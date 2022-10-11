using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlot : MonoBehaviour
{
    public GameObject selectedUnit;
    public LayerMask plotMask;
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, plotMask);
        if (hitData && Input.GetMouseButtonDown(0))
        {
            selectedUnit = hitData.transform.gameObject;
        }
    }
}
