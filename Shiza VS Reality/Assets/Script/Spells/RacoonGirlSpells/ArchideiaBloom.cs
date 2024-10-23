using UnityEngine;
using UnityEngine.UI;
public class ArchideiaBloom : Spell
{
    public override void Cast()
    {
        active = !active;
        switch (active)
        {
            case true:
                player.GetComponent<BaseÑharacteristic>().attack *= -1;
                GetComponent<Image>().color = new Color(0, 255, 0, 100);
                break;
            case false:
                player.GetComponent<BaseÑharacteristic>().attack *= -1;
                GetComponent<Image>().color = new Color(255, 255, 255, 100);
                break;
        }
    }
}