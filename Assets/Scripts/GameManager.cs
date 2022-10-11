using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public int currentLevel;
    UIManager uIManager;
    WaveManager waveManager;
    CameraMovementScript cm;
    SaveLoad save;
    UnitUIScript unitUI;
    // Start is called before the first frame update
    void Awake()
    {
        uIManager = GetComponent<UIManager>();
        waveManager = GameObject.FindObjectOfType<WaveManager>();
        save = GetComponent<SaveLoad>();
        cm = Camera.main.GetComponent<CameraMovementScript>();
        unitUI = GameObject.FindObjectOfType<UnitUIScript>();
        if(!PlayerPrefs.HasKey("SaveData"))
        {
            currentLevel = 1;
        }
        else
        {
            save.Load();
        }
    }

    private void Start()
    {
        //waveManager.enabled = false;  
        uIManager.CheckStateFunction(0); 
    }
    // Update is called once per frame
    public void LevelCheck()
    {
        cm.ButtonCheckFunction(cm.currentpos);
        unitUI.LockCheck(currentLevel);
    }

    public void GameOver()
    {
        Time.timeScale = 0;
    }
}
