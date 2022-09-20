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

    public int health;
    public int damage;
    public int fireRate;

    public GameObject projectile;
    // Start is called before the first frame update
    void Start()
    {
        WeaponSetup();
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
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;

        boxCollider = GetComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
    }
}
