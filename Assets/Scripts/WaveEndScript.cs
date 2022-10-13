using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveEndScript : MonoBehaviour
{
    public int enemiesDestroyed;
    public int resourcesEarned;
    public int unitsRepaired;

    public TextMeshProUGUI results;
    WaveSpawner waveSpawner;
    Minesmanager mines;
    public void Start()
    {
        waveSpawner = GameObject.FindObjectOfType<WaveSpawner>();
        mines = GameObject.FindObjectOfType<Minesmanager>();
        resourcesEarned = waveSpawner.resourcesEarned;
        enemiesDestroyed = waveSpawner.defeatedEnemies;
        unitsRepaired = waveSpawner.repairedUnits;
        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        var r = mines.resources;
        var t = "";
        yield return new WaitForSeconds(2);
        results.text = "Enemies Destroyed: ";
        yield return new WaitForSeconds(1);
        results.text += enemiesDestroyed;
        yield return new WaitForSeconds(1);
        results.text += "\nUnits Repaired: ";
        yield return new WaitForSeconds(1);
        results.text += unitsRepaired;
        yield return new WaitForSeconds(1);
        results.text += "\nResources: ";
        t = results.text;
        yield return new WaitForSeconds(1);
        results.text += r + " + " + resourcesEarned;
        yield return new WaitForSeconds(1);
        while(resourcesEarned != 0)
        {
            r += 1;
            resourcesEarned -= 1;
            results.text = results.text;
            results.text = t + r + " + " + resourcesEarned;
            yield return null;
        }
        results.text = t + r;
        mines.resources += resourcesEarned;
        yield return null;
    }
}
