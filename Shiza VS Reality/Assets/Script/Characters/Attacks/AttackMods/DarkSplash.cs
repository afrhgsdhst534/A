using UnityEngine;
public class DarkSplash : AttackModificatior
{
    public override void Spawn()
    {
        var s = chars.attackRange * 2.75f;
        float a = 0.2f+(s / 100f);
        obj.transform.localScale += new Vector3(a,a,a);
    }
}