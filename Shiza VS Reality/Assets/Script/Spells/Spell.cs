using UnityEngine;
public abstract class Spell : MonoBehaviour
{
    public Sprite picture;
    public int cost;
    public bool passive;
    public float cooldown;
    public int LvlLimit;
    public bool active = false;
    public bool switchable;
    public GameObject player;
    public int value;
    public virtual void OnAwake(GameObject obj)
    {
        active = false;
        player = obj;
    }
    public virtual void Cast()
    {
    }
    public virtual void Up()
    {
        LvlLimit--;
        player.GetComponent<BaseÑharacteristic>().lvlPoints--;
    }
}