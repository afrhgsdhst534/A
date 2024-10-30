using UnityEngine;
public class WeFightTOgether : Spell
{
    AllyCharacters ally;
    EnemyCharacters enemy;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        ally = AllyCharacters.instance;
        enemy = EnemyCharacters.instance;
        active = false;
    }
    public override void Cast()
    {
        active = !active;
        if (player.GetComponent<BaseÑharacteristic>().isAlly) {
            if (active)
            {
                for (int i = 0; i < ally.allAllyCharacters.Count; i++)
                {
                    ally.allAllyCharacters[i].GetComponent<BaseÑharacteristic>().attack -= player.GetComponent<BaseÑharacteristic>().attack;
                    player.GetComponent<BaseÑharacteristic>().attack += ally.allAllyCharacters[i].GetComponent<BaseÑharacteristic>().attack;
                }
            }
            else
            {
                for (int i = 0; i < ally.allAllyCharacters.Count; i++)
                {
                    player.GetComponent<BaseÑharacteristic>().attack -= ally.allAllyCharacters[i].GetComponent<BaseÑharacteristic>().attack;
                    ally.allAllyCharacters[i].GetComponent<BaseÑharacteristic>().attack += player.GetComponent<BaseÑharacteristic>().attack;
                }
            } 
        }
        else
        {
            if (active)
            {
                for (int i = 0; i < enemy.allEnemyCharacters.Count; i++)
                {
                    enemy.allEnemyCharacters[i].GetComponent<BaseÑharacteristic>().attack -= player.GetComponent<BaseÑharacteristic>().attack;
                    player.GetComponent<BaseÑharacteristic>().attack += enemy.allEnemyCharacters[i].GetComponent<BaseÑharacteristic>().attack;
                }
            }
            else
            {
                for (int i = 0; i < ally.allAllyCharacters.Count; i++)
                {
                    player.GetComponent<BaseÑharacteristic>().attack -= enemy.allEnemyCharacters[i].GetComponent<BaseÑharacteristic>().attack;
                    enemy.allEnemyCharacters[i].GetComponent<BaseÑharacteristic>().attack += player.GetComponent<BaseÑharacteristic>().attack;
                }
            }
        }
    }
}