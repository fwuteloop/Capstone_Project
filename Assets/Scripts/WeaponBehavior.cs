using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponBehavior : MonoBehaviour
{
    public float fireTimer;
    public int fireRadius;
    public bool isDetecting;

    public float detectionDelay = .3f;
    public LayerMask enemyMask;
    public string enemyTag = "Enemy";

    public LayerMask unitMask;
    public GameObject projectile;
    public GameObject currentEnemy;
    public GameObject brokenAnimate;

    Scroll scroll;
    WeaponSetup weaponSetup;
    GameObject target;
    public PlotData plot;
    void Start()
    {
        scroll = GetComponent<Scroll>();
        weaponSetup = GetComponentInParent<WeaponSetup>();
       
        var p = transform.parent;
        plot = p.transform.parent.GetComponent<PlotData>();
        //StartCoroutine(DetectEnemies());
        gameObject.layer = 10;
    }

    // Update is called once per frame
    void Update()
    {
        if (target != null && plot.health > 0)
        {
            transform.right = target.transform.position - transform.position;
            fireTimer += Time.deltaTime;
            if (fireTimer > weaponSetup.fireRate)
            {
                Fire(currentEnemy);
                fireTimer = 0;
            }
        }

        if (plot.health <= 0)
        {
            StopAllCoroutines();
            transform.eulerAngles = new Vector3(0, 0, 90);
            brokenAnimate.SetActive(true);
        }
        else
        {
            brokenAnimate.SetActive(false);
        }

        DetectEnemies();
        //Debug.Log(plot.health);

    }

    void DetectEnemies()
    {
        if (plot.health > 0)
        {
            isDetecting = true;
            //Debug.Log("i should be detecting");

            float delayTimer = 0;
            delayTimer += Time.deltaTime;

            if (delayTimer < detectionDelay)
            {

                GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
                float shortestDistance = Mathf.Infinity;
                GameObject nearestEnemy = null;

                foreach (GameObject enemy in enemies)
                {
                    float enemyDistance = Vector3.Distance(transform.position, enemy.transform.position);
                    if (enemyDistance < shortestDistance)
                    {
                        shortestDistance = enemyDistance;
                        nearestEnemy = enemy;
                    }
                }

                if (nearestEnemy != null && shortestDistance <= fireRadius)
                {
                    target = nearestEnemy;
                }
            }

        }

    }

    void Fire(GameObject enemy)
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.tag = "UProj";
        proj.GetComponent<ProjectileBehavior>().damage = weaponSetup.damage;
        proj.GetComponent<ProjectileBehavior>().target = target;
    }


}
