using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseScript : MonoBehaviour
{
    public float health = 3000;
    UIManager uiManager;
    GameManager gameManager;
    public float detectionRadius = 10f;
    public LayerMask enemyMask;

    // Start is called before the first frame update
    void Start()
    {
        uiManager = GameObject.Find("Game Manager").GetComponent<UIManager>();
        gameManager = GameObject.Find("Game Manager").GetComponent<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        if(health < 0)
        {
            uiManager.gameOverString = "You've been defeated...";
            uiManager.CheckStateFunction(3);
            gameManager.GameOver();
        }
    }

    private void FixedUpdate()
    {
        DetectCollision();
    }
    void DetectCollision()
    {
        Collider2D collider = Physics2D.OverlapCircle(transform.position, detectionRadius, enemyMask);
  
        if (collider != null)
        {
            float damage = collider.GetComponent<EnemySetup>().damage;
            TakeDamage(damage);
        }
    }
    void TakeDamage(float dmg)
    {
        health -= dmg;
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawSphere(transform.position, detectionRadius);
    }
}
