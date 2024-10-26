using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class SpellManager : MonoBehaviour
{
    public List<Spell> spells = new List<Spell>();
    private CanvasManager canvasManager;
    [HideInInspector]
    public Base—haracteristic chars;
    [HideInInspector]
    public InputButtons buttons;
    private void Start()
    {
        buttons = InputButtons.instance;
        chars = GetComponent<Base—haracteristic>();
        canvasManager = CanvasManager.instance;
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
        }
    }
    public void Add(Spell spell)
    {
        canvasManager.SpellVizualization(spell);
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