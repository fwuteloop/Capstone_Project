using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using TMPro;

public class WeaponInfoUIScript : MonoBehaviour, IPointerExitHandler
{
    public float currentHealth;
    public float fullHealth;
    public string wepName;
    public Image healthBar;
    public GameObject repairBtn;
    public TextMeshProUGUI nametxt, healthtxt;
    public PlotData currentPlotData;
    public bool canDestroy;
    public void Update()
    {
        nametxt.text = wepName;
        healthtxt.text = currentHealth + "\n/" + fullHealth;
        healthBar.fillAmount = currentHealth * 100 / fullHealth;
    }
    public void Repair()
    {
        currentPlotData.health = fullHealth;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
