using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    EnemySetup enemyValues;
    EnemyMovement enemyMovement;

    public GameObject projectile;

    Transform nearestUnit;
    float fireTimer;
    public int unitMask;
    float fireRadius = 10;

    public bool foundNearestUnit;
    // Start is called before the first frame update
    void Start()
    {
        unitMask = 10;
        foundNearestUnit = false;
        enemyValues = GetComponent<EnemySetup>();
        enemyMovement = GetComponent<EnemyMovement>();
        StartCoroutine(DetectUnits());
    }

    // Update is called once per frame
    void Update()
    {
        if (foundNearestUnit)
        {
            if (nearestUnit != null)
                transform.right = nearestUnit.transform.position - transform.position;
            else
                transform.right = enemyMovement.direction;
            fireTimer += Time.deltaTime;
            if (fireTimer > enemyValues.fireRate)
            {
                Instantiate(projectile, transform.position, Quaternion.identity);
                fireTimer = 0;
            }
        }

    }

    IEnumerator DetectUnits()
    {
        yield return new WaitForSeconds(.3f);
        Debug.Log("looking..");
        Collider2D collider = Physics2D.OverlapCircle(transform.position, fireRadius, unitMask);
        if(collider != null)
        {
            Debug.Log("found: " + collider.name);
            foundNearestUnit = true;
            nearestUnit = collider.transform;
        }
        else
        {
            nearestUnit = null;
            foundNearestUnit = false;
        }

        StartCoroutine(DetectUnits());
    }
}
