using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Weapon", menuName = "Create New Weapon")]
public class BaseWeapon : ScriptableObject
{
    public new string name;
    public string description;
    public Sprite icon;
    public float health;
    public float damage;
    public float fireRate;
    public Sprite sprite;
    public Sprite bottom;
    public int price;
}
