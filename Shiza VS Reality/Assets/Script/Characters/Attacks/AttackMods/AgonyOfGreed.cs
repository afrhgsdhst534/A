public class AgonyOfGreed : AttackModificatior
{
    public override void Damage(Base—haracteristic chars)
    {
        chars.DamageCalculations(this.chars.money, "magical");
    }
}