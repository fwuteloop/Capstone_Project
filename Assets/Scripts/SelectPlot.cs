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
    private void Start()
    {
        unitUI = GameObject.FindObjectOfType<UnitUIScript>();
    }
    void Update()
    {
        Vector3 worldPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        RaycastHit2D hitData = Physics2D.Raycast(new Vector2(worldPosition.x, worldPosition.y), Vector2.zero, 0, plotMask);
        if (hitData && Input.GetMouseButtonDown(0) && unitUI.hasUnit == true)
        {
            selectedUnit = hitData.transform.gameObject;
            SpawnWeapon(selectedUnit.transform.position);
            unitUI.hasUnit = false;
        }


    }
    public void SpawnWeapon(Vector3 location)
    {
        GameObject w = Instantiate(weaponHolder, location, Quaternion.identity);
        w.GetComponent<WeaponSetup>().weapon = weapons[unitUI.selectedWeapon];
    }
}
