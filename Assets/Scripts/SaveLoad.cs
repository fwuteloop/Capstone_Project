using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;

public class SaveLoad : MonoBehaviour
{
    public Minesmanager mine;
    public UIManager gm;

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
        data.level = gm.level;
        data.cache = mine.cache;
        for(int i = 0; i < 9; i++)
        {
            data.mineUpgrades[i] = mine.upgradeCheck[i];
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
            gm.level = data.level;
            mine.cache = data.cache;
            for (int i = 0; i < 9; i++)
            {
                mine.upgradeCheck[i] = data.mineUpgrades[i];
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
