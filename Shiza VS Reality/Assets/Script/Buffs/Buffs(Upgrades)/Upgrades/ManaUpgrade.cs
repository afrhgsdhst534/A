using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<BaseÑharacteristic>().maxMana += 100;
        player.GetComponent<BaseÑharacteristic>().manaRegen += 2;
    }
}
