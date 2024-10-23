using UnityEngine;
public class HealPotion : Item
{
    public override void OnUse()
    {
        player.GetComponent<BaseÑharacteristic>().curHp = player.GetComponent<BaseÑharacteristic>().maxHp;
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}