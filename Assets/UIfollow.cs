using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIfollow : MonoBehaviour
{
    public RectTransform r;
    public Vector3 offset;
    public Camera cam;
    public Canvas c;

    private void Start()
    {
        r = GetComponent<RectTransform>();
        cam = Camera.main;
        
    }
    void Update()
    {
        r.position = Input.mousePosition + offset;
        if(Input.GetMouseButtonUp(0))
        {
            Destroy(gameObject);
        }
    }

}
