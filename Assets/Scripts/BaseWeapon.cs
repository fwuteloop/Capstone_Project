using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BaseWeapon : MonoBehaviour
{
    public Weapon weapon;

    public new string name;
    public string description;

    public Sprite sprite;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Scroll scroll;

    public int health;
    public int damage;

    public float fireRate;
    private float fireTimer;
    public int fireRadius;
    public bool firing;

    public float detectionDelay = .3f;
    public LayerMask enemyMask;

    public GameObject projectile;
    public GameObject currentEnemy;
    private void Awake()
    {
        WeaponSetup();
    }
    void Start()
    {
        ComponentSetup();
        StartCoroutine(DetectEnemies());
    }

    // Update is called once per frame
    void Update()
    {
        if (firing)
        {
            fireTimer += Time.deltaTime;
            if (fireTimer > fireRate)
            {
                Fire(currentEnemy);
                fireTimer = 0;
            }
        }
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
        if (currentEnemy != null)
        {
            Debug.Log(enemy.transform.position);
            Instantiate(projectile, transform.position, Quaternion.identity).GetComponent<BaseProjectile>();
            projectile.GetComponent<BaseProjectile>().target = enemy.transform.position;
        }
    }
    void WeaponSetup()
    {
        name = weapon.name;
        description = weapon.description;
        sprite = weapon.sprite;

        health = weapon.health;
        damage = weapon.damage;
        fireRate = weapon.fireRate;
        
    }

    void ComponentSetup()
    {
        if (GetComponent<SpriteRenderer>() == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        if (GetComponent<BoxCollider2D>() == null)
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        if (GetComponent<Rigidbody2D>() == null)
            rigidBody = gameObject.AddComponent<Rigidbody2D>();

        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = 1;
        boxCollider.size = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
        boxCollider.isTrigger = true;
        scroll = GetComponent<Scroll>();

        rigidBody.bodyType = RigidbodyType2D.Kinematic;
    }
}
