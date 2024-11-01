using UnityEngine;
public class DarkSplash : AttackModificatior
{
    public override void Spawn()
    {
        var s = chars.attackRange * 1.4f;
        float a = 0.2f+(s / 100f);
        obj.transform.localScale += new Vector3(a, a, a);
        if (transform.childCount <=0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                var d = obj.transform.GetChild(i);
                d.localScale += new Vector3(a, a, a);
            }
        }
    }
}