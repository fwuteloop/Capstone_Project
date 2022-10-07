using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class upgradeInfo : MonoBehaviour
{
    public MineUpgrade u;
    public int index;
    public TextMeshProUGUI priceText;

    public void Start()
    {
        var b = gameObject.transform.Find("Price Panel");
        var p = b.gameObject.transform.Find("Price text");
        priceText = p.GetComponent<TextMeshProUGUI>();
        priceText.text = u.cost[index].ToString();
        //Debug.Log(u.cost[index]);
    }
}
