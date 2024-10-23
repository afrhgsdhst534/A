using UnityEngine;

public class ManaPotion : Item
{
    public override void OnUse()
    {
        player.GetComponent<Base�haracteristic>().curMana = player.GetComponent<Base�haracteristic>().maxMana;
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}
