using UnityEngine;
public class BadApple : Item
{
    public override void OnUse()
    {
        player.GetComponent<BaseÑharacteristic>().DamageCalculations(player.GetComponent<BaseÑharacteristic>().maxHp, "magical");
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}