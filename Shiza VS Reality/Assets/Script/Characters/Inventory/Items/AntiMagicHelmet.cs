using UnityEngine;
public class AntiMagicHelmet : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<Base�haracteristic>().magicResist += 100;
        player.GetComponent<Base�haracteristic>().magicDamage -= 50;
    }
    public override void OnDrop()
    {
        player.GetComponent<Base�haracteristic>().magicResist -= 100;
        player.GetComponent<Base�haracteristic>().magicDamage += 50;
        base.OnDrop();
    }
}
