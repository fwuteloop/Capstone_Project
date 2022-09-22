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
    public BoxCollider2D boxCollider;
    public SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody;
    public int health;
    public int damage;
    public int fireRate;

    public GameObject projectile;

    private void Awake()
    {
        WeaponSetup();
    }
    void Start()
    {
        ComponentSetup();
    }

    // Update is called once per frame
    void Update()
    {
    }

    void WeaponSetup()
    {
        name = weapon.name;
        description = weapon.description;
        sprite = weapon.sprite;

        health = weapon.health;
        damage = weapon.damage;
        fireRate = weapon.fireRate;

        projectile = weapon.projectile;
       
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

        rigidBody.bodyType = RigidbodyType2D.Kinematic;
    }
}
