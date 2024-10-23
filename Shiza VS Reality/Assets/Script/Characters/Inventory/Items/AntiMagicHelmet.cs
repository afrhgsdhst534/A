using UnityEngine;
public class AntiMagicHelmet : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().magicResist += 100;
        player.GetComponent<BaseÑharacteristic>().magicDamage -= 50;
    }
    public override void OnDrop()
    {
        player.GetComponent<BaseÑharacteristic>().magicResist -= 100;
        player.GetComponent<BaseÑharacteristic>().magicDamage += 50;
        base.OnDrop();
    }
}
