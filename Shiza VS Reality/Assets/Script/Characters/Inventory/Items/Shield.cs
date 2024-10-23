using UnityEngine;
using UnityEngine.UI;
public class Shield : Item
{
    bool active;

    public override void OnPick(GameObject obj)
    {
        base.OnPick(obj);
        player.GetComponent<BaseÑharacteristic>().armour += 25;
        player.GetComponent<BaseÑharacteristic>().magicResist += 25;
    }
    public override void OnDrop()
    {
        if (active)
        {
            OnUse();
        }
        player.GetComponent<BaseÑharacteristic>().armour -= 25;
        player.GetComponent<BaseÑharacteristic>().magicResist -= 25;
        base.OnDrop();
    }
    public override void OnUse()
    {
        active = !active;
        var bc = player.GetComponent<BaseÑharacteristic>();
        switch (active)
        {
            case true:
                gameObject.GetComponent<Image>().color = new Color(255, 255, 0, 100);
                player.GetComponent<BaseÑharacteristic>().armour -= 25;
                player.GetComponent<BaseÑharacteristic>().magicResist -= 25;
                player.GetComponent<RelativeObjs>().stone.SetActive(true);
                break;
            case false:
                gameObject.GetComponent<Image>().color = new Color(255, 255, 255, 100);
                bc.armour += 25;
                bc.magicResist += 25;
                player.GetComponent<RelativeObjs>().stone.SetActive(false);
                break;
        }
    }
}