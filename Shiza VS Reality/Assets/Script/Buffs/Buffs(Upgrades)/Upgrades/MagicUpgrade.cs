using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<BaseÑharacteristic>().magicDamage += 30;
    }
}
