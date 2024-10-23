using UnityEngine;
using UnityEngine.UI;

public class GloveOfHeist : Item
{
    private bool active;
    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().armour += 50;
    }
    public override void OnDrop()
    {
        if (active)
        {
            OnUse();
        }
        player.GetComponent<BaseÑharacteristic>().armour -= 50;
        base.OnDrop();
    }
    public override void OnUse()
    {
        active = !active;
        var bc = player.GetComponent<BaseÑharacteristic>();
        switch (active)
        {
            case true:
                gameObject.GetComponent<Image>().color = new Color(0, 255, 0, 100);
                bc.armour -= 50;
                bc.attackSpeed += 10;
                break;
            case false:
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                bc.armour += 50;
                bc.attackSpeed -= 10;
                break;
        }
    }
}
