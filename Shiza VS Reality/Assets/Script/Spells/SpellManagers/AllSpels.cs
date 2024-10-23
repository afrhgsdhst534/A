using UnityEngine;
using System.Collections.Generic;
public class AllSpels : MonoBehaviour
{
    public List<Spell> allSpells = new List<Spell>();
    public static AllSpels instance;
    private void Start()
    {
        instance = this;
    }
    private void OnEnable()
    {
        for (int i = 0; i < allSpells.Count; i++)
        {
            var temp = allSpells[i];
            int rand = Random.Range(i, allSpells.Count);
            allSpells[i] = allSpells[rand];
            allSpells[rand] = temp;
        }
    }
}