using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeavyArmour : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<Base�haracteristic>().armour += 100;
        player.GetComponent<Base�haracteristic>().magicResist += 100;
    }
    public override void OnDrop()
    {
        player.GetComponent<Base�haracteristic>().armour -= 100;
        player.GetComponent<Base�haracteristic>().magicResist -= 100;
        base.OnDrop();
    }
}
