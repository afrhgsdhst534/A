using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<BaseÑharacteristic>().attack += 30;
    }
}
