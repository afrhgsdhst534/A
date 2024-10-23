using UnityEngine;
public class BattleAxe : Item
{
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().attack += 50;
    }
    public override void OnDrop() {
        player.GetComponent<BaseÑharacteristic>().attack -= 50;
        base.OnDrop();
    }
    public override void OnUse()
    {
        if(ally)
        if(!player.GetComponent<BaseÑharacteristic>().isAttacking&&player.GetComponent<Attack>().attackObject!=null)
        {
            player.GetComponent<Attack>().StartCoroutine(player.GetComponent<Attack>().OnAttackEnemy());
        }
    }
}