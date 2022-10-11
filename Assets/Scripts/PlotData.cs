using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlotData : MonoBehaviour
{
    public GameObject myUnit;

    float unitHealth;
    int unitInt;

    public BaseWeapon unitType;
    private float detectionRadius;
    private int unitMask;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if(IsOccupied())
        {
            StoreValue();
        }

    }

    void StoreValue()
    {
        unitHealth = myUnit.GetComponent<WeaponSetup>().health;

    }
    bool IsOccupied()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, detectionRadius, unitMask);
        if (collider != null)
        {
            myUnit = collider.gameObject;
            return true;
        }
        else
            return false;
    }

}
