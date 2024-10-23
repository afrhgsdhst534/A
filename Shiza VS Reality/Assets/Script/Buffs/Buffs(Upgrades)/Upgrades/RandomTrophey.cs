using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomTrophey : Upgrade
{
    public override void OnUpgrade(GameObject player)
    {
        player.GetComponent<Base�haracteristic>().money += Random.Range(29,35);
    }
}
