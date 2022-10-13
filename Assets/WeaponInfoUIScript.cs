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
    public TextMeshProUGUI nametxt, healthtxt, pricetxt;
    public int repairPrice, fullPrice;
    public PlotData currentPlotData;
    Minesmanager mines;
    private void Start()
    {
        gameObject.SetActive(false);
        mines = GameObject.FindObjectOfType<Minesmanager>();
    }
    public void Update()
    {
        nametxt.text = wepName;
        healthtxt.text = currentHealth + "\n/" + fullHealth;
        pricetxt.text = repairPrice.ToString();
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
        if(mines.resources >= repairPrice)
        {
            currentPlotData.health = fullHealth;
            mines.Transaction(false, repairPrice);
            currentPlotData.ActivatePanel();
        }
        else
        {
            StartCoroutine(mines.AnimateResourcesText(mines.resourcesTextWave));
        }
        
    }

    public void RemoveWeapon()
    {
        mines.Transaction(true, fullPrice);
        currentPlotData.ResetFunction();
        gameObject.SetActive(false);
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        gameObject.SetActive(false);
    }
}
