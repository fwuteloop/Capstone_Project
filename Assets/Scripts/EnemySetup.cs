using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySetup : MonoBehaviour
{
    public BaseEnemy enemy;

    public new string name;
    public string description;
    public Sprite sprite;
    public float health;
    public float fireRate;
    public bool longRange;

    SpriteRenderer spriteRenderer;
    BoxCollider2D boxCollider;
    Rigidbody2D rigidBody;

    private void Awake()
    {
        ComponentSetup();
    }

    // Start is called before the first frame update
    void Start()
    {
        
        ValueSetup();
    }

    void ValueSetup()
    {
        name = enemy.name;
        description = enemy.description;
        sprite = enemy.sprite;

        health = enemy.health;
        fireRate = enemy.fireRate;
        longRange = enemy.longRange;
    }

    void ComponentSetup()
    {
        if (GetComponent<SpriteRenderer>() == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = 1;

        if (GetComponent<BoxCollider2D>() == null)
            boxCollider = gameObject.AddComponent<BoxCollider2D>();
        boxCollider.size = new Vector2(sprite.bounds.size.x, sprite.bounds.size.y);
        boxCollider.isTrigger = true;

        if (GetComponent<Rigidbody2D>() == null)
            rigidBody = gameObject.AddComponent<Rigidbody2D>();

        rigidBody.gravityScale = 0;
        rigidBody.drag = 1.5f;
        rigidBody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}