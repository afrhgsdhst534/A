using UnityEngine;
public class WeFightTOgether : Spell
{
    AllyCharacters ally;
    EnemyCharacters enemy;
    public Buff buff;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        buff.player = player;
        ally = AllyCharacters.instance;
        enemy = EnemyCharacters.instance;
        active = false;
        if (player.GetComponent<BaseÑharacteristic>().isAlly)
        {
            if (ally.allAllyCharacters.Count > 0)
            {
                for (int i = 1; i < ally.allAllyCharacters.Count; i++)
                {
                    ally.allAllyCharacters[i].GetComponent<BuffManager>().BuffAdd(buff);
                }
            }
        }
        else
        {
            if (enemy.allEnemyCharacters.Count > 0)
            {
                for (int i = 1; i < enemy.allEnemyCharacters.Count; i++)
                {
                    enemy.allEnemyCharacters[i].GetComponent<BuffManager>().BuffAdd(buff);
                }
            }
        }
    }
    public override void Up()
    {
        base.Up();
        OnAwake(player);
    }
}