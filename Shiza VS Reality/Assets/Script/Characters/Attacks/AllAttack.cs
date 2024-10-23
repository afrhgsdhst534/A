using System.Collections.Generic;
using UnityEngine;
public class AllAttack : MonoBehaviour
{
    public bool isObj;
    public List<IAttackObject> allObj = new List<IAttackObject>();
    public List<AttackModificatior> allMods = new List<AttackModificatior>();
    private void OnEnable()
    {
        switch (isObj)
        {
            case true:
                for (int i = 0; i < allObj.Count; i++)
                {
                    var temp = allObj[i];
                    int rand = Random.Range(i, allObj.Count);
                    allObj[i] = allObj[rand];
                    allObj[rand] = temp;
                }
                break;
            case false:
                for (int i = 0; i < allMods.Count; i++)
                {
                    var temp = allMods[i];
                    int rand = Random.Range(i, allMods.Count);
                    allMods[i] = allMods[rand];
                    allMods[rand] = temp;
                }
                break;
        }
    }
}