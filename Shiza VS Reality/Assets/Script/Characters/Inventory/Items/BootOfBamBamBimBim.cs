using UnityEngine;
using UnityEngine.UI;
public class BootOfBamBamBimBim : Item
{
    private int value;
    private bool active;
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<Base�haracteristic>().speed += 50;
    }
    public override void OnDrop()
    {
        if(active)
        {
            OnUse();
        }
        player.GetComponent<Base�haracteristic>().speed -= 50;
        base.OnDrop();
    }
    public override void OnUse()
    {
        active = !active;
        var bc = player.GetComponent<Base�haracteristic>();
        switch (active)
        {
            case true:
                gameObject.GetComponent<Image>().color = new Color(0, 255, 255, 100);
                value = bc.speed;
                bc.speed = 300;
                bc.maxHp /=2;
                bc.curHp += 1;
                break;
            case false:
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                bc.speed = value;
                bc.maxHp *= 2;
                break;
        }
    }
}