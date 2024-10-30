using UnityEngine;
public class InfiniteLight : AttackModificatior
{
    public override void Damage(Base—haracteristic chars)
    {
        var dist = Vector3.Distance(this.chars.transform.position, chars.transform.position);
        int rounded = System.Convert.ToInt32(dist);
        chars.DamageCalculations(this.chars.attack/4*rounded,"physical");
    }
}