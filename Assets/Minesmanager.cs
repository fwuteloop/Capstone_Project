using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Minesmanager : MonoBehaviour
{
    public MineUpgrade[] upgrades;
    public int resources;
    public int cache;
    public int rate;
    public int[] levels;
    private float timer;
    public float waitPeriod;
    public float duration;
    public bool animated;
    public TextMeshProUGUI collectText, resourcesText;
    public Color collectImageColor, disabledImageColor, collectTextColor, disabledTextColor;
    public Button collectButton;
    public GameObject[] upgradeButtons;
    public bool[] upgradeCheck;

    public void Start()
    {
        UpgradeCheck();
        if(cache > 0)
        {
            collectText.color = collectTextColor;
            collectButton.GetComponent<Image>().color = collectImageColor;
        }
        else
        {
            collectText.color = disabledTextColor;
            collectButton.GetComponent<Image>().color = disabledImageColor;
        }
    }

    public void Update()
    {
        timer -= Time.deltaTime;
        resourcesText.text = resources.ToString();
        if (timer <= 0)
        {
            cache += rate;
            timer = waitPeriod;
        }

        if(cache > 0)
        {
            collectText.text = "Collect " + cache + "!";
            if (!animated)
            {
                FillFunction();
            }
            
        }
        else
        {
            collectText.text = "collect in " + Mathf.RoundToInt(timer).ToString();
        }
    }

    public void FillFunction()
    {
        StartCoroutine(AnimateCollectButton(disabledImageColor, collectImageColor, disabledTextColor, collectTextColor, true));
        animated = true;
    }
    public void CollectButton()
    {
        resources += cache;
        cache = 0;
        animated = false;
        StartCoroutine(AnimateCollectButton(collectImageColor, disabledImageColor, collectTextColor, disabledTextColor, false));
    }


    public IEnumerator AnimateCollectButton(Color imageStart, Color imageEnd, Color textStart, Color textEnd, bool activated)
    {
        var time = 0f;
        
        while(time < duration)
        {
            float t = time / duration;
            collectText.color = Color.Lerp(textStart, textEnd, t);
            collectButton.GetComponent<Image>().color = Color.Lerp(imageStart, imageEnd, t);
            time += Time.deltaTime;
            yield return null;
        }
        collectButton.GetComponent<Image>().color = imageEnd;
        collectText.color = textEnd;
        yield return null;
    }
    public IEnumerator AnimateResourcesText()
    {
        var time = 0f;
        while(time < duration)
        {
            float t = time / duration;
            resourcesText.color = Color.Lerp(Color.white, Color.red, t);
            time += Time.deltaTime;
            yield return null;
        }
        resourcesText.color = Color.red;
        time = 0f;
        while (time < duration)
        {
            float t = time / duration;
            resourcesText.color = Color.Lerp(Color.red, Color.white, t);
            time += Time.deltaTime;
            yield return null;
        }
        resourcesText.color = Color.white;
        yield return null;
    }

    public void UpgradeApply(int i)
    {
        var stor = upgradeButtons[i].GetComponent<upgradeInfo>();
        var upgrade = stor.u;
        var cost = upgrade.cost[stor.index];
        var addRate = upgrade.rateAdded[stor.index];

        if(resources > cost)
        {
            resources -= cost;
            rate += addRate;
            upgradeCheck[i] = true;
            UpgradeCheck();
        }
        else
        {
            StartCoroutine(AnimateResourcesText());
        }
    }

    public void UpgradeCheck()
    {
        for(int i = 0; i < upgradeButtons.Length; i++)
        {
            var p = upgradeButtons[i].transform.Find("Price Panel");
            var b = upgradeButtons[i].transform.Find("Button");
            if(upgradeCheck[i])
            {
                p.gameObject.SetActive(false);
                b.gameObject.SetActive(false);
            }
        }
    }
}
