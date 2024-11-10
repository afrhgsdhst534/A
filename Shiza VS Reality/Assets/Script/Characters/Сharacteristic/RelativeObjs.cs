using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;
public class RelativeObjs : MonoBehaviour
{
    public GameObject shop;
    public GameObject body;
    public GameObject stone;
    public List<Spell> spells;
    public IAttackObject attackObj;
    public List<AttackModificatior> attackMods;
    public UniqueSpell us;
    public List<GameObject> deadly;
    public List<GameObject> defendly;
    public List<GameObject> books;
    private MovementChanger move=>GetComponent<MovementChanger>();
    ButtonsPM can;
    private async void Start()
    {
        await Task.Delay(100);
        can = ButtonsPM.instance;
        var a = can.shopButtons.transform.GetComponentsInChildren<Hides>();
        deadly = a[1].objs;
        defendly = a[2].objs;
        books = a[3].objs;
    }
    public void OnLvlUp()
    {
        if (move.movement == "ai")
        {
            var r = Random.Range(0, 3);
            var a = GetComponent<Attack>();
            var s = GetComponent<SpellManager>();
            var i = GetComponent<InventoryManager>();
            switch (r)
            {
                case 1: a.AddModificator(attackMods[0]); break;
                case 2: s.Add(spells[0]); break;
                case 3: i.PickUp(defendly[0].GetComponent< ShopBuyItem>().item); break;
            }
        }
        else
        {
            var e = can.canvasManager.enableOnLvl;
            e.SetActive(true);
            Instantiate(deadly[Random.Range(0, deadly.Count)],can.canvasManager.enableOnLvl.transform);
            Instantiate(defendly[Random.Range(0, defendly.Count)], can.canvasManager.enableOnLvl.transform);
            Instantiate(books[Random.Range(0, books.Count)], can.canvasManager.enableOnLvl.transform);
        }
    }
}