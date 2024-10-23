using UnityEngine;
using UnityEngine.UI;
public class BattleBrawler : Spell
{
    private Sprite thisSprite;
    private Base—haracteristic bc;
    public Sprite sprite;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        thisSprite = GetComponent<Image>().sprite;
        LvlLimit = 0;
        bc = player.GetComponent<Base—haracteristic>();
        bc.magicDamage += bc.attack;
    }
    public override void Cast()
    {
        active = !active;
        switch (active)
        {
            case true:
                GetComponent<Image>().sprite = thisSprite;
                bc.magicDamage -= bc.attack;
                bc.attack += bc.magicDamage;
                break;
            case false:
                GetComponent<Image>().sprite = sprite;
                bc.attack -= bc.magicDamage;
                bc.magicDamage += bc.attack;
                break;
        }
    }
}