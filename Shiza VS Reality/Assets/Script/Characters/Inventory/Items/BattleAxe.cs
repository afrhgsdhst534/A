using UnityEngine;
public class BattleAxe : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<Base�haracteristic>().attack += 50;
    }
    public override void OnDrop() {
        player.GetComponent<Base�haracteristic>().attack -= 50;
        base.OnDrop();
    }
    public override void OnUse()
    {
        if(ally)
        if(!player.GetComponent<Base�haracteristic>().isAttacking&&player.GetComponent<Attack>().attackObject!=null)
        {
            player.GetComponent<Attack>().StartCoroutine(player.GetComponent<Attack>().OnAttackEnemy());
        }
    }
}