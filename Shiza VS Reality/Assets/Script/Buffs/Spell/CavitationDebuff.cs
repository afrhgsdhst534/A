using UnityEngine;
public class CavitationDebuff : Buff
{
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
    }
    public override void PlusValue(int value)
    {
        base.PlusValue(value);
        if (this.value > 9)
        {
            player.GetComponent<BaseÑharacteristic>().curHp -= player.GetComponent<BaseÑharacteristic>().maxHp - 1;
            player.GetComponent<BuffManager>().BuffRemove(this);
        }
    }
}