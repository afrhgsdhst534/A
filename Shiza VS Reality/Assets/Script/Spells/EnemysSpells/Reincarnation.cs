using UnityEngine;
public class Reincarnation : Spell
{
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        Cast();
        LvlLimit = 30;
    }
    public override void Cast()
    {
        if (cooldown< 1&&player.GetComponent<Base�haracteristic>().curMana>=1000)
        {
            player.GetComponent<Base�haracteristic>().immortal = true;
            cooldown = 99-value;
            player.GetComponent<Base�haracteristic>().curMana -= 1000;
        }
    }
    public override void Up()
    {
        base.Up();
        value++;
    }
}