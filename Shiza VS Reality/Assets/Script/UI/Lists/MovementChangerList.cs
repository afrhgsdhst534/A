public class MovementChangerList : AList
{
    private CanvasManager can;
    MovementChanger move;
    protected override void OnEnable()
    {
        isRand = false;
        can = CanvasManager.instance;
        move = can.pickedChar.GetComponent<MovementChanger>();
        base.OnEnable();
    }
    public override void Use(int i)
    {
        switch (i)
        {
            case 0:
                move.movement = "arrow";
                move.Next();
                break;
            case 1:
                move.movement = "mouse";
                move.Next();
                break;
            case 2:
                move.movement = "ai";
                move.Next();
                break;
        }
    }
}