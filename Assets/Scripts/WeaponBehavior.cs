using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public float fireTimer;
    public int fireRadius;
    public bool firing;

    public float detectionDelay = .3f;
    public LayerMask enemyMask;
    public string enemyTag = "Enemy";

    public LayerMask unitMask;
    public GameObject projectile;
    public GameObject currentEnemy;

    Scroll scroll;
    WeaponSetup weaponSetup;
    GameObject target;
    PlotData plot;
    void Start()
    {
        scroll = GetComponent<Scroll>();
        weaponSetup = GetComponentInParent<WeaponSetup>();
        plot = transform.parent.GetComponent<PlotData>();
        StartCoroutine(DetectEnemies());
        gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null)
        {
            transform.right = target.transform.position - transform.position;
            fireTimer += Time.deltaTime;
            if (fireTimer > weaponSetup.fireRate)
            {
                Fire(currentEnemy);
                fireTimer = 0;
            }
        }

        if (weaponSetup.health < 0)
            Destroy(gameObject);


    }

    IEnumerator DetectEnemies()
    {
        yield return new WaitForSeconds(detectionDelay);

        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(enemyDistance < shortestDistance)
            {
                shortestDistance = enemyDistance;
                nearestEnemy = enemy;
            }
        }

        if(nearestEnemy != null && shortestDistance <= fireRadius)
        {
            target = nearestEnemy;
        }

        StartCoroutine(DetectEnemies());

    }

    void Fire(GameObject enemy)
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.tag = "UProj";
        proj.GetComponent<ProjectileBehavior>().damage = weaponSetup.damage;
        proj.GetComponent<ProjectileBehavior>().target = target;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EProj")
        {
            Debug.Log("ouch");
            plot.health -= collision.gameObject.GetComponent<ProjectileBehavior>().damage;
        }
    }
}
