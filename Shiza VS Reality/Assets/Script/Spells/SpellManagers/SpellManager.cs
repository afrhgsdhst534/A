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
    public List<int> spellValue = new List<int>();
    public List<float> spellCooldown = new List<float>();
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
                    children.GetComponentInChildren<Text>().text = spellCooldown[i].ToString();
                    spellCooldown[i] -= Time.deltaTime;
                    var number = Mathf.Round(spellCooldown[i]);
                    children.GetComponent<Text>().text = number.ToString();
                }
                catch { }
            }
        }
    }
    public void Add(Spell spell)
    {
        spellValue.Add(1);
        spellCooldown.Add(spell.cooldown);
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