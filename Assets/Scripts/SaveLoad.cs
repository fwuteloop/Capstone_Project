using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public Minesmanager mine;
    public GameManager gm;
    public PlotData[] plots;

    public void Awake()
    {
        Load();
    }

    public void Update()
    {
        if(Input.GetKeyDown(KeyCode.R))
        {
            Restart();
        }
    }
    public void Save()
    {
        SaveData data = new SaveData();
        data.resources = mine.resources;
        data.rate = mine.rate;
        data.level = gm.currentLevel;
        data.cache = mine.cache;
        for(int i = 0; i < 9; i++)
        {
            data.mineUpgrades[i] = mine.upgradeCheck[i];
        }
        for (int i = 0; i < 40; i++)
        {
            data.isOccupied[i] = plots[i].isOccupied;
            data.unitType[i] = plots[i].unitIndex;
            data.weaponHealth[i] = plots[i].health;
        }
        //need to add weap locations. health, and base health

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/SaveData.json", json);
        PlayerPrefs.SetString("SaveData", "true");
        Debug.Log("saved done");
    }

    public void Load()
    {
        if(PlayerPrefs.HasKey("SaveData"))
        {
            string json = File.ReadAllText(Application.dataPath + "/saveData.json");
            SaveData data = JsonUtility.FromJson<SaveData>(json);

            mine.resources = data.resources;
            mine.rate = data.rate;
            gm.currentLevel = data.level;
            mine.cache = data.cache;
            for (int i = 0; i < 9; i++)
            {
                mine.upgradeCheck[i] = data.mineUpgrades[i];
            }
            for (int i = 0; i < 40; i++)
            {
                plots[i].isOccupied = data.isOccupied[i];
                plots[i].unitIndex = data.unitType[i];
                plots[i].health = data.weaponHealth[i];
            }
            //need to add weap locations. health, and base health
            mine.UpgradeCheck();
        }
    }
    public void Restart()
    {
        SaveData data = new SaveData();
        data.resources = 0;
        data.rate = mine.initialRate;
        data.level = 0;
        data.cache = 0;
        for (int i = 0; i < 9; i++)
        {
            data.mineUpgrades[i] = false;
        }

        //need to add weap locations. health, and base health

        string json = JsonUtility.ToJson(data);
        File.WriteAllText(Application.dataPath + "/SaveData.json", json);
        PlayerPrefs.SetString("SaveData", "true");
        Debug.Log("saved done");
        Load();
    }
}
