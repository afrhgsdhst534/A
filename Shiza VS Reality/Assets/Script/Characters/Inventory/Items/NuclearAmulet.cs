using UnityEngine;
public class NuclearAmulet : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().maxMana += 100;
        player.GetComponent<BaseÑharacteristic>().manaRegen += 3;
        player.GetComponent<BaseÑharacteristic>().magicDamage += 50;
        player.GetComponent<BaseÑharacteristic>().attackRange -= 15;
    }
    public override void OnDrop()
    {
        player.GetComponent<BaseÑharacteristic>().maxMana -= 100;
        player.GetComponent<BaseÑharacteristic>().manaRegen -= 3;
        player.GetComponent<BaseÑharacteristic>().magicDamage -= 50;
        player.GetComponent<BaseÑharacteristic>().attackRange += 15;
        base.OnDrop();
    }
}