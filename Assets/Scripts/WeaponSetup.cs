using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponSetup : MonoBehaviour
{
    public BaseWeapon weapon;

    public new string name;
    public string description;
    public float health;
    public float damage;
    public float fireRate;

    private GameObject top;
    private GameObject bottom;

    public Sprite sprite;
    private BoxCollider2D boxCollider;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody;
    private Scroll scroll;

    private void Start()
    {
        ValueSetup();
        ComponentSetup();
        SpriteSetUp();
    }

    void ValueSetup()
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

        //spriteRenderer.sprite = sprite;
        //spriteRenderer.sortingOrder = 4;
        boxCollider.size = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
        boxCollider.isTrigger = true;
        scroll = GetComponent<Scroll>();

        rigidBody.bodyType = RigidbodyType2D.Kinematic;
        rigidBody.gravityScale = 0;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    void SpriteSetUp()
    {
        transform.Find("Weapon").GetComponent<SpriteRenderer>().sprite = weapon.sprite;
        if (weapon.bottom != null)
        {
            transform.Find("Base").GetComponent<SpriteRenderer>().sprite = weapon.bottom;
        }
    }
}
