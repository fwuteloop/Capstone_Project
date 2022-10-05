using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Projectile", fileName = "New Projectile")]
public class BaseProjectile : ScriptableObject
{
    public float speed;
    public float expiration;

    public Sprite sprite;
}
