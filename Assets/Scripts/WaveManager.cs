using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveManager : MonoBehaviour
{
    public int waveCount;
    public int currentEnemyCount;
    public int maxEnemyCount;

    public bool waveEnded;

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
        waveCount = 0;
        StartCoroutine(SpawnEnemies(lvl1Enemies, currentSpawnPoint.position));
    }



    public IEnumerator SpawnEnemies(GameObject[] enemyset, Vector3 spawnPoint)
    {
        yield return new WaitForSeconds(spawnInterval);
        if (waveCount < 4)
        {
            for (int i = 0; i < maxEnemyCount; i++)
            {
                if (currentEnemyCount < maxEnemyCount && waveEnded == false)
                {
                    Instantiate(enemyset[Random.Range(0, enemyset.Length)], spawnPoint, Quaternion.identity);
                    yield return new WaitForSeconds(Random.Range(1.3f, 3.4f));
                    currentEnemyCount += 1;
                    i++;
                }
                else if(currentEnemyCount == maxEnemyCount)
                {
                    waveEnded = true;
                    waveCount += 1;
                }
            }
        }
    }

}
