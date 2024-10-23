using UnityEngine;
public class NuclearAmulet : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<Base�haracteristic>().maxMana += 100;
        player.GetComponent<Base�haracteristic>().manaRegen += 3;
        player.GetComponent<Base�haracteristic>().magicDamage += 50;
        player.GetComponent<Base�haracteristic>().attackRange -= 15;
    }
    public override void OnDrop()
    {
        player.GetComponent<Base�haracteristic>().maxMana -= 100;
        player.GetComponent<Base�haracteristic>().manaRegen -= 3;
        player.GetComponent<Base�haracteristic>().magicDamage -= 50;
        player.GetComponent<Base�haracteristic>().attackRange += 15;
        base.OnDrop();
    }
}