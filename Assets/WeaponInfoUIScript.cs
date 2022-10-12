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

    public void Update()
    {
        nametxt.text = wepName;
        healthtxt.text = currentHealth + "\n/" + fullHealth;
        healthBar.fillAmount = Mathf.Clamp(currentHealth / fullHealth, 0, 1f);

        if (currentHealth > fullHealth/2)
        {
            repairBtn.SetActive(false);
            healthBar.color = Color.green;
        }
        else if (currentHealth < fullHealth/2 && currentHealth > fullHealth/4)
        {
            repairBtn.SetActive(false);
            healthBar.color = Color.yellow;
        }
        else if (currentHealth < fullHealth/4 && currentHealth >0)
        {
            repairBtn.SetActive(false);
            healthBar.color = Color.red;
        }
        else if(healthBar.fillAmount <= 0)
        {
            repairBtn.SetActive(true);
        }
    }
    public void Repair()
    {
        currentPlotData.health = fullHealth;
        currentPlotData.ActivatePanel();
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
