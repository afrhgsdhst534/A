using UnityEngine;
public class BadApple : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        if (obj.GetComponent<MinionsMovement>().enabled)
        {
            OnUse();
        }
    }
    public override void OnUse()
    {
        player.GetComponent<Base�haracteristic>().DamageCalculations(player.GetComponent<Base�haracteristic>().maxHp, "magical");
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}