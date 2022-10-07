using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class waveplaceholder : MonoBehaviour
{
    public GameObject gm;
 
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            gm.GetComponent<UIManager>().CheckStateFunction(2);
        }
    }
}
