using UnityEngine;
public class Bracer : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().maxHp += 200;
        player.GetComponent<BaseÑharacteristic>().hpRegen += 4;
    }
    public override void OnDrop()
    {
        player.GetComponent<BaseÑharacteristic>().maxHp -= 200;
        player.GetComponent<BaseÑharacteristic>().hpRegen -= 4;
        base.OnDrop();
    }
}