public class SpeedStealer : AttackModificatior
{
    public override void Damage(Base—haracteristic chars)
    {
        chars.speed -= 3;
        this.chars.speed += 3;
    }
}