using UnityEngine;
public class BadApple : Item
{
    public override void OnUse()
    {
        player.GetComponent<Base�haracteristic>().DamageCalculations(player.GetComponent<Base�haracteristic>().maxHp, "magical");
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}