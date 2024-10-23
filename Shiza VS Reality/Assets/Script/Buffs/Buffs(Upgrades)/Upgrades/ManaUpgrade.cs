using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManaUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<Base�haracteristic>().maxMana += 100;
        player.GetComponent<Base�haracteristic>().manaRegen += 2;
    }
}
