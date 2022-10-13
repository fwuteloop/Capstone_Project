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
    public int index;

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
            if(gameObject.tag =="cancel")
            {
                gameObject.SetActive(false);
            }
            else
            {
                Destroy(gameObject);
            }

        }
    }

}
