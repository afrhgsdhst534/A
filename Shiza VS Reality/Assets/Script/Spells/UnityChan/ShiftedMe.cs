using System.Threading.Tasks;
public class ShiftedMe : Spell
{
    public override void Cast()
    {
        player.gameObject.SetActive(false);
    }
    public async void Next()
    {
        await Task.Delay(2500);
        player.gameObject.SetActive(true);
    }
}