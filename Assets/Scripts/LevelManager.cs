using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelManager : MonoBehaviour
{
    WaveManager waveManager;
    UIManager uiManager;
    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
        waveManager = GameObject.FindObjectOfType<WaveManager>();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
