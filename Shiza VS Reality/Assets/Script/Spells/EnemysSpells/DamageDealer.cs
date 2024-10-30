using UnityEngine;
using System.Collections;
public class DamageDealer : Spell
{
    Attack a;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        a = player.GetComponent<Attack>();
        a.onAttack += A;
    }
    private void A()
    {
        if (player.GetComponent<Attack>().attackObject != null)
            StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(a.delay);
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