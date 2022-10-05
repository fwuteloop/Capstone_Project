using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class WaveEndScript : MonoBehaviour
{
    public int enemiesDestroyed;
    public int resourcesEarned;
    public int unitsDestroyed;

    public TextMeshProUGUI results;

    public void Start()
    {
        StartCoroutine(Animate());
    }

    public IEnumerator Animate()
    {
        var r = 0;
        var t = "";
        yield return new WaitForSeconds(2);
        results.text = "Enemies Destroyed: ";
        yield return new WaitForSeconds(1);
        results.text += enemiesDestroyed;
        yield return new WaitForSeconds(1);
        results.text += "\nunitsDestroyed: ";
        yield return new WaitForSeconds(1);
        results.text += unitsDestroyed;
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
        yield return null;
    }
}
