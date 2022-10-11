using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelectPlot : MonoBehaviour
{
    public GameObject selectedUnit;
    public UnitUIScript unitUI;
    public LayerMask plotMask;

    public BaseWeapon[] weapons;

    public GameObject weaponHolder;

    public Minesmanager mines;
    private void Start()
    {
        unitUI = GameObject.FindObjectOfType<UnitUIScript>();
        mines = GameObject.FindObjectOfType < Minesmanager>();
    }
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, plotMask);
        if (hitData && Input.GetMouseButtonDown(0) && unitUI.hasUnit == true)
        {
            SpawnWeapon(hitData.transform.position);
            unitUI.hasUnit = false;
        }


    }
    public void SpawnWeapon(Vector3 location)
    {
        GameObject w = Instantiate(weaponHolder, location, Quaternion.identity);
        BaseWeapon bw = weapons[unitUI.selectedWeapon];
        w.GetComponent<WeaponSetup>().weapon = bw;
        mines.resources -= bw.price; // money is only spent when weapon is placed down
    }
}
