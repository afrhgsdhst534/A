using UnityEngine;
public class WaterProofPants : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().maxHp += 50;
        player.GetComponent<BaseÑharacteristic>().hpRegen += 1;
    }
    public override void OnDrop()
    {
        player.GetComponent<BaseÑharacteristic>().maxHp -= 50;
        player.GetComponent<BaseÑharacteristic>().hpRegen -= 1;
        base.OnDrop();
    }
    void Update()
    {
        player.GetComponent<BaseÑharacteristic>().canMove = true;
}
}