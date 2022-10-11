using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileSetup : MonoBehaviour
{
    public BaseProjectile projectile;

    public float speed;
    public Sprite sprite;

    public CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    public Rigidbody2D rigidBody2D;
    // Start is called before the first frame update
    void Awake()
    {
      

    }
    private void Start()
    {
        ComponentSetup();
    }

    void ComponentSetup()
    {
        Debug.Log("componentsetup");
        if (GetComponent<SpriteRenderer>() == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        if (GetComponent<CircleCollider2D>() == null)
            circleCollider = gameObject.AddComponent<CircleCollider2D>();
        if (GetComponent<Rigidbody2D>() == null)
            rigidBody2D = gameObject.AddComponent<Rigidbody2D>();
        sprite = projectile.sprite;

        circleCollider.isTrigger = true;
        circleCollider.radius = sprite.bounds.max.x;
        rigidBody2D.gravityScale = 0;
      
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = 2;

        speed = projectile.speed;
    }
}
