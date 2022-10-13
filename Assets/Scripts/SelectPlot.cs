using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlot : MonoBehaviour
{
    public GameObject selectedUnit;
    public UnitUIScript unitUI;
    public LayerMask plotMask;
    public RaycastHit2D hitData;
    public BaseWeapon[] weapons;

    public GameObject weaponHolder;
    public GameObject infoPanel;
    public Minesmanager mines;
    private void Start()
    {
        unitUI = GameObject.FindObjectOfType<UnitUIScript>();
        mines = GameObject.FindObjectOfType < Minesmanager>();
    }
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, plotMask);
        if (hitData)
        {
            var plot = hitData.transform.gameObject;
            if(!plot.GetComponent<PlotData>().isOccupied)
            {
                if (Input.GetMouseButtonDown(0) && unitUI.hasUnit == true)
                {
                    SpawnWeapon(plot.transform.position, plot);
                    unitUI.hasUnit = false;
                }
            }
            else
            {
                infoPanel.SetActive(true);
                infoPanel.transform.position = Camera.main.WorldToScreenPoint(plot.transform.position);
                plot.GetComponent<PlotData>().ui = infoPanel.GetComponent<WeaponInfoUIScript>();
                plot.GetComponent<PlotData>().ActivatePanel();
            }  
        }
        else
        {
           // infoPanel.SetActive(false);
        }


    }
    public void SpawnWeapon(Vector3 location, GameObject plot)
    {
        BaseWeapon bw = weapons[unitUI.selectedWeapon];

        GameObject w = Instantiate(weaponHolder, location, Quaternion.identity);
            w.transform.SetParent(plot.transform);

            w.GetComponent<WeaponSetup>().weapon = bw;
            var p = plot.GetComponent<PlotData>();
            p.myUnit = w;
            p.unitIndex = unitUI.selectedWeapon;
            p.isOccupied = true;


        
    }
}
