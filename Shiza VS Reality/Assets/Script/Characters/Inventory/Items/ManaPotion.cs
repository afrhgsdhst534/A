using UnityEngine;

public class ManaPotion : Item
{
    public override void OnUse()
    {
        player.GetComponent<BaseÑharacteristic>().curMana = player.GetComponent<BaseÑharacteristic>().maxMana;
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}
