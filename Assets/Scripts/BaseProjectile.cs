using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseProjectile : MonoBehaviour
{
    public Projectile projectile;

    public float speed;
    public Vector3 target;
    public Vector3 direction;
    public LayerMask enemyLayer;

    public float damage;
    public float expiration;
    private float expirationTime;
    public Sprite sprite;

    private CircleCollider2D circleCollider;
    private SpriteRenderer spriteRenderer;
    private Rigidbody2D rigidBody2D;
    private void Awake()
    {
        ProjectileSetup();
    }
    // Start is called before the first frame update
    void Start()
    {
        ComponentSetup();
        direction = (target - transform.position).normalized * speed * Time.deltaTime;
        rigidBody2D.velocity = new Vector2(direction.x, direction.y);
        Destroy(gameObject, expiration);
    }

    // Update is called once per frame
    void Update()
    {

    }

    void ProjectileSetup()
    {
        speed = projectile.speed;
        damage = projectile.damage;
        expiration = projectile.expiration;

        sprite = projectile.sprite;
    }

    void ComponentSetup()
    {
        if (GetComponent<SpriteRenderer>() == null)
            spriteRenderer = gameObject.AddComponent<SpriteRenderer>();
        if (GetComponent<CircleCollider2D>() == null)
            circleCollider = gameObject.AddComponent<CircleCollider2D>();
        if (GetComponent<Rigidbody2D>() == null)
            rigidBody2D = gameObject.AddComponent<Rigidbody2D>();

        circleCollider.isTrigger = true;
        circleCollider.radius = sprite.bounds.max.x;
        rigidBody2D.gravityScale = 0;
        spriteRenderer.sprite = sprite;
        spriteRenderer.sortingOrder = 2;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.layer == 7)
        {
            Debug.Log("enemy");
            Destroy(gameObject);
        }
    }
}
