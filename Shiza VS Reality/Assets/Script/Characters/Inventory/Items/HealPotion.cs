using UnityEngine;
public class HealPotion : Item
{
    public override void OnUse()
    {
        player.GetComponent<Base�haracteristic>().curHp = player.GetComponent<Base�haracteristic>().maxHp;
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}