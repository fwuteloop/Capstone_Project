using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileBehavior: MonoBehaviour
{
    public GameObject target;
    public Vector3 direction;
    public float damage;

    ProjectileSetup projectileSetup;

    // Start is called before the first frame update
    void Start()
    {
     
        projectileSetup = GetComponent<ProjectileSetup>();
        if (target != null)
            direction = (target.transform.position - transform.position).normalized * projectileSetup.speed;
        else
            Destroy(gameObject);

        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        projectileSetup.rigidBody2D.velocity = new Vector2(direction.x, direction.y) * Time.deltaTime;

        if (target == null)
            projectileSetup.circleCollider.enabled = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.layer == target.layer && collision.gameObject != null)
        {
            Destroy(gameObject);
        }
 
    }
}
