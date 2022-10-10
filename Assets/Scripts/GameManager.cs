using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    UIManager uIManager;
    WaveManager waveManager;
    // Start is called before the first frame update
    void Awake()
    {
        uIManager = GetComponent<UIManager>();
        waveManager = GameObject.FindObjectOfType<WaveManager>();
        if(!PlayerPrefs.HasKey("SaveData"))
        {
            currentLevel = 1;
        }
    }

    private void Start()
    {
        waveManager.enabled = false;  
        uIManager.CheckStateFunction(0); 
    }
    // Update is called once per frame
    void Update()
    {
        
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
