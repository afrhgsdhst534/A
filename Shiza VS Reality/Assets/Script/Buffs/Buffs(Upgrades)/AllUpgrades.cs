using System.Collections.Generic;
using UnityEngine;
public class AllUpgrades : MonoBehaviour
{
    public List<Upgrade> upgrades;
    private void OnEnable()
    {
        for (int i = 0; i < upgrades.Count; i++)
        {
            var temp = upgrades[i];
            int rand = Random.Range(i, upgrades.Count);
            upgrades[i] = upgrades[rand];
            upgrades[rand] = temp;
        }
    }
}