using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehavior : MonoBehaviour
{
    EnemySetup enemyValues;
    EnemyMovement enemyMovement;

    public GameObject projectile;

    GameObject nearestUnit;
    public float fireTimer;
    public LayerMask unitMask;
    float fireRadius = 10;

    public bool firing;

    WaveSpawner waveSpawner;
    // Start is called before the first frame update
    void Start()
    {
        waveSpawner = GameObject.FindObjectOfType<WaveSpawner>();
        enemyValues = GetComponent<EnemySetup>();
        enemyMovement = GetComponent<EnemyMovement>();
        StartCoroutine(DetectUnits());
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            if(nearestUnit != null)
                transform.right = nearestUnit.transform.position - transform.position;
            fireTimer += Time.deltaTime;
            if (fireTimer > enemyValues.fireRate)
            {
                Fire(nearestUnit);
                fireTimer = 0;
            }
        }

        if (enemyValues.health < 0)
        {
            waveSpawner.aliveEnemies.Remove(gameObject);
            Destroy(gameObject);
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
                //Debug.Log(collider.gameObject.name);
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
            GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
            proj.tag = "EProj";
        proj.GetComponent<ProjectileBehavior>().damage = enemyValues.damage;
            proj.GetComponent<ProjectileBehavior>().target = unit;
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "UProj")
        {
            enemyValues.health -= collision.gameObject.GetComponent<ProjectileBehavior>().damage;
        }
    }
}
