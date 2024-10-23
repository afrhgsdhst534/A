using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyArmour : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().armour += 100;
        player.GetComponent<BaseÑharacteristic>().magicResist += 100;
    }
    public override void OnDrop()
    {
        player.GetComponent<BaseÑharacteristic>().armour -= 100;
        player.GetComponent<BaseÑharacteristic>().magicResist -= 100;
        base.OnDrop();
    }
}
