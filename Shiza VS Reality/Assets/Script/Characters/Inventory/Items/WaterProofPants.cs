using UnityEngine;
public class WaterProofPants : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<Base�haracteristic>().maxHp += 50;
        player.GetComponent<Base�haracteristic>().hpRegen += 1;
    }
    public override void OnDrop()
    {
        player.GetComponent<Base�haracteristic>().maxHp -= 50;
        player.GetComponent<Base�haracteristic>().hpRegen -= 1;
        base.OnDrop();
    }
    void Update()
    {
        player.GetComponent<Base�haracteristic>().canMove = true;
}
}