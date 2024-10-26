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
        player.GetComponent<BaseÑharacteristic>().DamageCalculations(player.GetComponent<BaseÑharacteristic>().maxHp, "magical");
        player.GetComponent<InventoryManager>().items.Remove(this);
        Destroy(gameObject);
    }
}