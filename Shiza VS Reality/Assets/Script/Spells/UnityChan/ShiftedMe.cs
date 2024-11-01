using System.Threading.Tasks;
public class ShiftedMe : Spell
{
    public override void Cast()
    {
        if (cooldown<1)
        {
            Next();
        }
    }
    public async void Next()
    {
        player.gameObject.SetActive(false);
        await Task.Delay(2500);
        player.gameObject.SetActive(true);
        cooldown = 8;
    }
}