using UnityEngine;
using UnityEngine.UI;
public class ArchideiaBloom : Spell
{
    public GameObject obj1;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        obj1 = Instantiate(Resources.Load<GameObject>("Love aura"), player.transform.position, Quaternion.identity);
        obj1.transform.SetParent(player.transform);
        obj1.SetActive(false);
    }
    public override void Cast()
    {
        active = !active;
        switch (active)
        {
            case true:
                player.GetComponent<BaseÑharacteristic>().attack *= -1;
                GetComponent<Image>().color = new Color(0, 255, 0, 100);
                obj1.SetActive(true);
                break;
            case false:
                player.GetComponent<BaseÑharacteristic>().attack *= -1;
                GetComponent<Image>().color = new Color(255, 255, 255, 100);
                obj1.SetActive(false);
                break;
        }
    }
}