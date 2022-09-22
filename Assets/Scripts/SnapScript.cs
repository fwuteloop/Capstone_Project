using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnapScript : MonoBehaviour
{

    Scroll scroll;
    private void Awake()
    {
        scroll = GetComponent<Scroll>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 3)
        {
            //change its sprite to something else
        }
    }

    private void OnTriggerExitr2D(Collider2D collision)
    {
        if (collision.gameObject.layer == 3)
        {
            //change its sprite to back to the original
        }
    }


    private void OnTriggerStay2D(Collider2D collision)
    {
        if (scroll.isFollowing == false && collision.gameObject.layer == 3)
        {
            Debug.Log("Snap to plot");
            gameObject.transform.position = collision.transform.position;
            scroll.canFollow = false;
        }
    }
}
