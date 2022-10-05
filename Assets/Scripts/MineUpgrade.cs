using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "New Mine Upgrade", menuName = "Create New Mine Upgrade")]

public class MineUpgrade : ScriptableObject
{
    public new string name;
    public string[] description;
    public Sprite[] icons;
    public int[] rateAdded;
    public int[] cost;
    
}
