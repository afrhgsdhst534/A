using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HpUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<Base�haracteristic>().maxHp += 100;
        player.GetComponent<Base�haracteristic>().hpRegen += 2;
    }
}
