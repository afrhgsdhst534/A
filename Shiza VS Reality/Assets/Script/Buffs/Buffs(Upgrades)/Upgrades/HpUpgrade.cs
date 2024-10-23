using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<BaseÑharacteristic>().maxHp += 100;
        player.GetComponent<BaseÑharacteristic>().hpRegen += 2;
    }
}
