using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Wave
{
    public int enemyCount;
    public GameObject[] enemies;
    public float spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    public Wave[] waves;
    public Transform[] spawnPoints;

    private Transform currentSpawnPoint;
    private Wave currentWave;
    public int currentWaveInt;
    public int waveCount;

    private float nextSpawn;

    public float gracePeriod;
    public bool canSpawn;
    public bool levelEnd;

    GameManager gm;
    UIManager uiManager;
    public List<GameObject> aliveEnemies;
    public int defeatedEnemies;
    public int repairedUnits;

    private void Awake()
    {
        levelEnd = false;
    }
    private void Start()
    {
        uiManager = GameObject.FindObjectOfType<UIManager>();
        gm = GameObject.FindObjectOfType<GameManager>();
    }
    private void Update()
    {
        currentWave = waves[currentWaveInt];
        CreateWave();

        if(!canSpawn && aliveEnemies.Count == 0 && !levelEnd)
        {
            
            currentWave.enemyCount = currentWave.enemies.Length;

            gracePeriod += Time.deltaTime;
            if (waveCount != 2)
            {
                if (gracePeriod > 5)
                {
                    waveCount += 1;
                    //warning UI image appears in a coroutine
                    canSpawn = true;
                    gracePeriod = 0;
                }
            }
            else if (waveCount == 2)
            {
                waveCount += 1;
            }
        }

        if(waveCount == 3)
        {
            levelEnd = true;
            canSpawn = false;
            uiManager.CheckStateFunction(2);
            waveCount = 0;
            this.enabled = false;
        }
    }

    public void AddRepairUnit()
    {
        repairedUnits += 1;
    }

    public void ResetLevelEnd()
    {
        currentWaveInt += 1;
        levelEnd = false;
    }

    public void CreateWave()
    {
        
        if (canSpawn && nextSpawn < Time.time)
        {
            GameObject randEnemy = currentWave.enemies[Random.Range(0, currentWave.enemies.Length)];
            ChangeSpawnPoint();
            GameObject e = Instantiate(randEnemy, currentSpawnPoint.position, Quaternion.identity);
            aliveEnemies.Add(e);
            currentWave.enemyCount--;
            nextSpawn = Time.time + currentWave.spawnInterval;
            if(currentWave.enemyCount == 0)
            {
                canSpawn = false;
            }
        }
    }

    void ChangeSpawnPoint()
    {
      switch(gm.currentLevel)
        {
            case 1:
                currentSpawnPoint = spawnPoints[0];
                break;
            case 2:
                currentSpawnPoint = spawnPoints[1];
                break;
            case 3:
                currentSpawnPoint = spawnPoints[2];
                break;
            case 4:
                currentSpawnPoint = spawnPoints[Random.Range(3,5)];
                break;
            case 5:
                currentSpawnPoint = spawnPoints[Random.Range(6, 8)];
                break;
            case 6:
                currentSpawnPoint = spawnPoints[Random.Range(9, 11)];
                break;
        }
    }
}
