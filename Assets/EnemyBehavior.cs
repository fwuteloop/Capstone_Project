using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    EnemySetup enemyValues;
    EnemyMovement enemyMovement;

    public GameObject projectile;

    GameObject nearestUnit;
    float fireTimer;
    public LayerMask unitMask;
    float fireRadius = 10;

    public bool firing;
    // Start is called before the first frame update
    void Start()
    {
        enemyValues = GetComponent<EnemySetup>();
        enemyMovement = GetComponent<EnemyMovement>();
        StartCoroutine(DetectUnits());
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            transform.right = nearestUnit.transform.position - transform.position;
            fireTimer += Time.deltaTime;
            if (fireTimer > enemyValues.fireRate)
            {
                Fire(nearestUnit);
                fireTimer = 0;
            }
        }

    }

    IEnumerator DetectUnits()
    {
        yield return new WaitForSeconds(.3f);
        if (enemyValues.longRange == true)
        {
            Collider2D collider = Physics2D.OverlapCircle(transform.position, fireRadius, unitMask);
            if (collider != null)
            {
                Debug.Log(collider.gameObject.name);
                nearestUnit = collider.gameObject;
                firing = true;
            }
            else
            {
                nearestUnit = null;
                firing = false;
            }
        }
        StartCoroutine(DetectUnits());
    }

    void Fire(GameObject unit)
    {
        if (unit != null)
        {
            Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<BaseProjectile>();
            projectile.GetComponent<BaseProjectile>().target = unit;
            Debug.Log(unit);
        }
        else
            return;
    }
}
