using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Create New Weapon")]
public class Weapon : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite sprite;
    public int health;
    public int damage;
    public int fireRate;
    public GameObject projectile;
}
