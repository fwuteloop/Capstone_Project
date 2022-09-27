using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UnitUIScript : MonoBehaviour
{
    public TextMeshProUGUI buttonText;
    public bool isOpen;
    public bool canClick = true;
    public Vector3 openPos, closedPos;
    public float duration;
    public Canvas c;
    public GameObject newWeapon;
    public GameObject previewPanel;
    public Sprite[] weaponSprites;
    public Weapon[] weapons;
    //0 - terra
    //1 - tundra
    //2 - aerial
    //3 - galactic
    public TextMeshProUGUI wepName, wepDesc, wepStats;
    public Image wepPreview;

    public void PreviewCheck(bool canShow, int i)
    {
        if(canShow)
        {
            var w = weapons[i];
            previewPanel.SetActive(true);
            wepPreview.sprite = w.sprite;
            wepDesc.text = w.description;
            wepName.text = w.name;
            wepStats.text = "Health: " + w.health + "\nDamage: " + w.damage + "\nFire Rate: " + w.fireRate;
        }
        else
        {
            previewPanel.SetActive(false);
        }
    }
    IEnumerator UIAnimator()
    {
        var time = 0f;
        Vector3 start = Vector3.zero;
        Vector3 target = Vector3.zero;
        if(isOpen)
        {
            start = closedPos;
            target = openPos;
        }
        else
        {
            start = openPos;
            target = closedPos;
        }

        while(time < duration)
        {
            float t = time / duration;
            t = Mathf.Sin(t * Mathf.PI * .5f);
            GetComponent<RectTransform>().anchoredPosition = Vector3.Lerp(start, target, t);
            time += Time.deltaTime;
            Debug.Log("still running");
            yield return null;
        }
        Debug.Log("done running");
        GetComponent<RectTransform>().anchoredPosition = target;
        CheckButtonFunction();
        canClick = true;
        yield return null;
    }
    public void CheckButtonFunction()
    {
        if(isOpen)
        {
            buttonText.text = ">";
        }
        else
        {
            buttonText.text = "<";
        }
    }
    public void OpenButtonFunction()
    {
        if(canClick)
        {
            isOpen = !isOpen;
            StartCoroutine(UIAnimator());
            canClick = false;
        }
    }

    public void WeaponButton(int i)
    {
        var g = Instantiate(newWeapon, transform.position, Quaternion.identity);
        g.transform.SetParent(c.transform, false);
        g.GetComponent<Image>().sprite = weaponSprites[i];
        g.GetComponent<UIfollow>().index = i;
    }
}
