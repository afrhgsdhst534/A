public class FightTogether : AttackModificatior
{
    public override void Damage(Base—haracteristic chars)
    {
        chars.DamageCalculations(this.chars.attack / 4 * AllyCharacters.instance.allAllyCharacters.Count, "physical");
    }
}