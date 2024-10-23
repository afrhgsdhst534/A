public class AncientDamage : AttackModificatior
{
    public override void Damage(Base—haracteristic chars)
    {
        chars.DamageCalculations(this.chars.attack, "magical");
    }
}