using UnityEngine;
using System.Collections.Generic;
public class Cavitation : Spell
{
    AllyCharacters allyC;
    EnemyCharacters enemyC;
    ButtonOnClick onClick;
    public Buff buff;
    List<GameObject> allyArr;
    List<GameObject> enemyArr;
    float time = 10;
    string s;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        allyC = AllyCharacters.instance;
        enemyC = EnemyCharacters.instance;
        onClick ??= GetComponent<ButtonOnClick>();
        allyArr = allyC.allAllyCharacters;
        enemyArr = enemyC.allEnemyCharacters;
        allyArr = allyC.allAllyCharacters;
        s = buff.GetType().Name;
    }
    public override void Cast()
    {
        if (onClick.ally)
        {
            for (int i = 0; i < enemyArr.Count; i++)
            {
                float dist = Vector3.Distance(enemyArr[i].transform.position, player.transform.position);
               var manager = enemyArr[i].GetComponent<BuffManager>();
                if (dist <= 8)
                {
                    if (!manager.IFThereBuff(s))
                    {
                        manager.BuffAdd(buff);
                    }
                    time -= Time.deltaTime;
                    if (time <= 0)
                    {
                        time = 10;
                        if (manager.IFThereBuff(s))
                        {
                            manager.BuffByName(s);
                            if (manager.BuffByName(s).value < 10)
                            {
                                manager.BuffByName(s).PlusValue(1);
                            }
                        }
                    }
                }
                if(dist>5&& manager.IFThereBuff(s))
                {
                    manager.BuffRemove(manager.BuffByName(s));
                }
            }
        }
        else
        {
            for (int i = 0; i < allyArr.Count; i++)
            {
                float dist = Vector3.Distance(allyArr[i].transform.position, player.transform.position);
                var manager = allyArr[i].GetComponent<BuffManager>();
                if (dist <= 8)
                {
                    if (!manager.IFThereBuff(s))
                    {
                        manager.BuffAdd(buff);
                    }
                    time -= Time.deltaTime;
                    if (time <= 0)
                    {
                        time = 10;
                        if (manager.IFThereBuff(s))
                        {
                            manager.BuffByName(s);
                            if (manager.BuffByName(s).value < 10)
                            {
                                manager.BuffByName(s).PlusValue(1);
                            }
                        }
                    }
                }
                if (dist > 5 && manager.IFThereBuff(s))
                {
                    manager.BuffRemove(manager.BuffByName(s));
                }
            }
        }
    }
}