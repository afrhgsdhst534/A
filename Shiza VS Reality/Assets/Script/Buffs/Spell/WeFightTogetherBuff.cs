using UnityEngine;
public class WeFightTogetherBuff : Buff
{
    GameObject host;
    int money;
    int armour;
    int mr;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        host = obj;
        var o = host.GetComponent<BaseÑharacteristic>();
        var h = player.GetComponent<BaseÑharacteristic>();
        money = o.money;
        armour = o.armour;
        mr = o.magicResist;
        o.money = h.money;
        o.armour = h.armour;
        o.magicResist = h.magicResist;
    }
    private void OnDestroy()
    {
        var o = player.GetComponent<BaseÑharacteristic>();
        o.money = money;
        o.armour = armour;
        o.magicResist = mr;
    }
}