using UnityEngine;
using System.Threading.Tasks;
public class DamageDealer : Spell
{
    Attack a;
    int i;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        a = player.GetComponent<Attack>();
        a.onAttack += A;
    }
    private void A()
    {
        if (player.GetComponent<Attack>().attackObject != null&&i<=0)
        {
            Next();
        }
        i--;
    }
    async void Next()
    {
        await Task.Delay(900);
        i =1;
        a = player.GetComponent<Attack>();
        a.attackObject.bc = a.chars;
        a.attackObject.trans = a.transform;
        var m = Instantiate(a.attackObject.gameObject);
        m.GetComponent<IAttackObject>().isAlly = a.chars.isAlly;
        a.delay = a.chars.attackSpeed / 100f;
    }
    private void OnDestroy()
    {
        a.onAttack -= A;
    }
}