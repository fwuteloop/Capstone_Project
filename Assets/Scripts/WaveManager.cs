using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveThreshold = 3;
    public int currentWave;
    public int maxEnemyCount;

    public float spawnInterval;
    float spawnTimer;

    public Transform currentSpawnPoint;

    public GameObject[] lvl1Enemies;
    public GameObject[] lvl2Enemies;
    public GameObject[] lvl3Enemies;
    public GameObject[] lvl4Enemies;
    public GameObject[] lvl5Enemies;
    public GameObject[] lvl6Enemies;
    // Start is called before the first frame update
    void Start()
    {

        StartCoroutine(SpawnEnemies());
    }

    IEnumerator SpawnEnemies()
    {
        yield return new WaitForSeconds(spawnInterval);
        for(int i = 0; i < maxEnemyCount; i++)
        {
            Instantiate(lvl1Enemies[Random.Range(0, lvl1Enemies.Length)], currentSpawnPoint);
            Debug.Log("spawned enemy");
            i++;
        }
    }
}
