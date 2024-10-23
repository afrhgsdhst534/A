using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyPerSecond : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<BaseÑharacteristic>().moneyPerSecond += 1;
    }
}
