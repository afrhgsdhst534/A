using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ArmourUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<BaseÑharacteristic>().armour += 30;
    }
}
