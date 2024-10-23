using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagicResistUpgrade : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<Base�haracteristic>().magicResist += 30;
    }

}
