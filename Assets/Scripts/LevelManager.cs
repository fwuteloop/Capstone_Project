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

    public void CheckLevel(int lvl)
    {
        switch (lvl)
        {
            case 1:

                break;
            case 2:
                break;
            case 3:
                break;
            case 4:
                break;
            case 5:
                break;
            case 6:
                break;
        }
    }
}
