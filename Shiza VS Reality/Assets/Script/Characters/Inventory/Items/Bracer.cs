using UnityEngine;
public class Bracer : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<Base�haracteristic>().maxHp += 200;
        player.GetComponent<Base�haracteristic>().hpRegen += 4;
    }
    public override void OnDrop()
    {
        player.GetComponent<Base�haracteristic>().maxHp -= 200;
        player.GetComponent<Base�haracteristic>().hpRegen -= 4;
        base.OnDrop();
    }
}