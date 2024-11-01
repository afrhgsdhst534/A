using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellManager : MonoBehaviour
{
    public List<Spell> spells = new List<Spell>();
    [HideInInspector]
    public Base—haracteristic chars;
    [HideInInspector]
    public InputButtons buttons;
    private void Start()
    {
        buttons = InputButtons.instance;
        chars = GetComponent<Base—haracteristic>();
    }
    void Update()
    {
        for(int i = 0; i < spells.Count; i++)
        {
            if (!spells[i].GetComponent<ButtonOnClick>().spell.passive)
            {
                var children = spells[i].GetComponent<ButtonOnClick>().children;
                try
                {
                    children.GetComponentInChildren<Text>().text = spells[i].cooldown.ToString();
                    spells[i].cooldown -= Time.deltaTime;
                    var number = Mathf.Round(spells[i].cooldown);
                    children.GetComponent<Text>().text = number.ToString();
                }
                catch { }
            }
            if (spells[i].passive)
            {
                spells[i].Cast();
            }
        }
    }
    public void Add(Spell spell)
    {
        var SO = GetComponent<PlayersUIManager>().spells;
        GameObject obj = Instantiate(spell.gameObject, SO.transform.position, new Quaternion(0,0,0,0));
        GetComponent<SpellManager>().spells.Add(obj.GetComponent<Spell>());
        obj.GetComponent<Spell>().OnAwake(gameObject);
        obj.GetComponent<ButtonOnClick>().CheckUp();
        obj.transform.SetParent(SO.transform);
        obj.GetComponent<Image>().sprite = spell.picture;
        obj.GetComponent<ButtonOnClick>().spell = spell;
        obj.transform.localScale = Vector3.one;
        if (gameObject.GetComponent<Base—haracteristic>().isAlly)
        {
            obj.GetComponent<ButtonOnClick>().ally = true;
        }
    }
    public GameObject FindSpell(Spell spell)
    {
        GameObject a =null;
        try{
            for (int i = 0; i < spells.Count; i++)
            {
                if (spells[i].GetComponent<Spell>() == spell)
                {
                    a = spells[i].gameObject;
                }
            }
        }
        catch { }
        return a;
    }
}