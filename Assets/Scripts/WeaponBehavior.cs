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

    public LayerMask unitMask;
    public GameObject projectile;
    public GameObject currentEnemy;

    Scroll scroll;
    WeaponSetup weaponSetup;

    void Start()
    {
        scroll = GetComponent<Scroll>();
        weaponSetup = GetComponent<WeaponSetup>();
        StartCoroutine(DetectEnemies());
        unitMask = 10;
        gameObject.layer = unitMask;
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            transform.right = currentEnemy.transform.position - transform.position;
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

        Collider2D collider = Physics2D.OverlapCircle(transform.position, fireRadius, enemyMask);

        if (scroll.canFollow == false && scroll.isFollowing == false)
        {
            if (collider != null)
            {
                currentEnemy = collider.gameObject;
                firing = true;
            }
            else
            {
                currentEnemy = null;
                firing = false;
            }

        }
        StartCoroutine(DetectEnemies());

    }

    void Fire(GameObject enemy)
    {
        GameObject proj = Instantiate(projectile, transform.position, Quaternion.identity);
        proj.tag = "UProj";
        proj.GetComponent<ProjectileBehavior>().damage = weaponSetup.damage;
        proj.GetComponent<ProjectileBehavior>().target = currentEnemy;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "EProj")
        {
            weaponSetup.health -= collision.gameObject.GetComponent<ProjectileBehavior>().damage;
        }
    }
}