using UnityEngine;
using System.Collections.Generic;
using System.Threading.Tasks;
public class Modificateble : MonoBehaviour
{
    public List<AttackModificatior> mods;
    public IAttackObject ao;
    public List<Spell> spells;
    public List<Buff> buffs;
    public BuffManager b;
    public Attack a;
    public SpellManager s;
    void Start()
    {
         a = gameObject.GetComponent<Attack>();
         b = GetComponent<BuffManager>();
         s = GetComponent<SpellManager>();
        N();
    }
    async void N()
    {
        await Task.Delay(1000);
        if (ao != null)
        {
            a.AttackObjChanger(ao);
        }
        for (int i = 0; i < mods.Count; i++)
        {
            a.AddModificator(mods[i]);
        }
        for (int i = 0; i < spells.Count; i++)
        {
            s.Add(spells[i]);
        }
        for (int i = 0; i < buffs.Count; i++)
        {
            b.BuffAdd(buffs[i]);
        }
    }
}