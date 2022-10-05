using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Create New Enemy", fileName = "New Enemy")]
public class BaseEnemy : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;
    public float fireRate;
    public float health;
    public bool longRange;
    public float damage;
}
