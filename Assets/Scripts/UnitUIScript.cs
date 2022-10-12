using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUIScript : MonoBehaviour
{
    public TextMeshProUGUI arrowText;
    public bool isOpen;
    public bool canClick = true;
    public Vector3 openPos, closedPos;
    public float duration;

    public Canvas c;
    public GameObject newWeapon;
    public GameObject unitPreviewPanel;
    public GameObject unitButtons, mineButtons;
    public GameObject[] locks;
   public Sprite[] weaponSprites;
    public BaseWeapon[] weapons;
    public int selectedWeapon;
    //0 - terra
    //1 - tundra
    //2 - aerial
    //3 - galactic
    public MineUpgrade[] upgrades;
    //0 better tools
    //1 more workers
    //2 minecarts
    public TextMeshProUGUI prevName, wepDesc, wepStats, upgradeDesc, priceText;
    public Image prevImg, resourcesImg;
    public GameObject confirmPanel;
    public UIManager uim;
    public GameManager gm;
    SelectPlot selectPlot;
    Minesmanager mines;

    public bool hasUnit;

    private void Start()
    {
        selectPlot = GameObject.FindObjectOfType<SelectPlot>();
        mines = GameObject.FindObjectOfType<Minesmanager>();
    }

    // Universal UI stuff
    IEnumerator UIAnimator()
    {
        var time = 0f;
        Vector3 start = Vector3.zero;
        Vector3 target = Vector3.zero;
        if (isOpen)
        {
            start = closedPos;
            target = openPos;
        }
        else
        {
            start = openPos;
            target = closedPos;
        }

        while (time < duration)
        {
            float t = time / duration;
            t = Mathf.Sin(t * Mathf.PI * .5f);
            GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(start, target, t);
            time += Time.deltaTime;
            //Debug.Log("still running");
            yield return null;
        }
        //Debug.Log("done running");
        GetComponent<RectTransform>().anchoredPosition = target;
        CheckButtonFunction();
        canClick = true;
        yield return null;
    }
    public void CheckButtonFunction()
    {
        if (isOpen)
        {
            arrowText.text = ">";
        }
        else
        {
            arrowText.text = "<";
        }
    }
    public void OpenButtonFunction()
    {
        if (canClick)
        {
            isOpen = !isOpen;
            StartCoroutine(UIAnimator());
            canClick = false;
        }
    }
    // Just Unit Stuff
    public void LockCheck(int i)
    {
        switch(i)
        {
            case 3:
                locks[0].SetActive(false);
                break;
            case 5:
                locks[1].SetActive(false);
                break;
            case 6:
                locks[2].SetActive(false);
                break;
        }
    }
    public void UnitPreviewCheck(bool canShow, int i)
    {
        if (canShow)
        {
            var w = weapons[i];
            unitPreviewPanel.SetActive(true);
            if(i == 1 && gm.currentLevel < 3 || i == 2 && gm.currentLevel < 5 || i == 3 && gm.currentLevel < 6)
            {
                prevImg.sprite = w.icon;
                prevImg.GetComponent<Image>().color = Color.blue;
                wepDesc.text = "";
                prevName.text = w.name;
                wepStats.text = "";
                priceText.text = "";
                resourcesImg.gameObject.SetActive(false);
                upgradeDesc.text = "Weapon unavailable.";
            }
            else
            {
                prevImg.sprite = w.icon;
                prevImg.GetComponent<Image>().color = Color.white;
                wepDesc.text = w.description;
                prevName.text = w.name;
                wepStats.text = "Health: " + w.health + "\nDamage: " + w.damage + "\nFire Rate: " + w.fireRate;
                resourcesImg.gameObject.SetActive(true);
                priceText.text = w.price.ToString();
                upgradeDesc.text = "";
            }
            
        }
        else
        {
            unitPreviewPanel.SetActive(false);
        }
    }
    public void WeaponButton(int i)
    {
        var g = Instantiate(newWeapon, transform.position, Quaternion.identity);
        g.transform.SetParent(c.transform, false);
        g.GetComponent<Image>().sprite = weaponSprites[i];
        g.GetComponent<UIfollow>().index = i;
        selectedWeapon = i;
        hasUnit = true;
        
    }
    public void StartWaveButton(int i)
    {
        switch (i)
        {
            case 0:
                confirmPanel.SetActive(true);
                break;
            case 1:
                confirmPanel.SetActive(false);
                uim.CheckStateFunction(1);
                break;
            case 2:
                confirmPanel.SetActive(false);
                break;
        }
    }
    //Just Mines Stuff
    public void MinesPreviewCheck(bool canShow, int i, int level)
    {
        if (canShow)
        {
            var m = upgrades[i];
            unitPreviewPanel.SetActive(true);
            prevImg.sprite = m.icons[level];
            prevImg.GetComponent<SpriteRenderer>().color = Color.white;
            upgradeDesc.text = m.description[level];
            prevName.text = m.name;
            wepDesc.text = "";
            wepStats.text = "";
            priceText.text = "";
        }
        else
        {
            unitPreviewPanel.SetActive(false);
        }
    }
}


