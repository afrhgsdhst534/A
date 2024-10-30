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
            player.GetComponent<Base�haracteristic>().curHp -= player.GetComponent<Base�haracteristic>().maxHp - 1;
            player.GetComponent<BuffManager>().BuffRemove(this);
        }
    }
}