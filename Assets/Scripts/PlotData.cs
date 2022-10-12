using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotData : MonoBehaviour
{
    public float health;
    public int unitIndex;
    public GameObject myUnit;
    public GameObject weaponPrefab;
    public BaseWeapon[] weapons;
    public bool isOccupied;
    public GameObject infoPanel;
    public WeaponInfoUIScript ui;
    public void Start()
    {
        if(isOccupied && myUnit == null)
        {
            myUnit = Instantiate(weaponPrefab);
            myUnit.transform.SetParent(gameObject.transform);
            myUnit.GetComponent<WeaponSetup>().weapon = weapons[unitIndex];
        }
    }
    public void ActivatePanel()
    {
        ui.wepName = weapons[unitIndex].name;
        ui.currentHealth = health;
        ui.fullHealth = weapons[unitIndex].health;
        ui.currentPlotData = GetComponent<PlotData>();
        //Debug.Log("mouse over plot");
    }


}
