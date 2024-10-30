using UnityEngine;
public class YouAreMine : Spell
{
    SpritesManager manager;
    AllyCharacters allyC;
    EnemyCharacters enemyC;
    MovementChanger mc;
    Base—haracteristic bc;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        mc = player.GetComponent<MovementChanger>();
        bc = player.GetComponent<Base—haracteristic>();
        manager = SpritesManager.instance;
        allyC = AllyCharacters.instance;
        enemyC = EnemyCharacters.instance;
    }
    public override void Cast()
    {
        active = true;
    }
    public void Update()
    {
        try
        {
            if (active)
            {
                switch (mc.movement)
                {
                    case "arrow":
                    case "mouse":
                        manager.ChangeCursor(manager.badCursor);
                        if (Input.GetMouseButtonDown(0))
                        {
                            var cam = Camera.main;
                            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                            RaycastHit hit;
                            if (Physics.Raycast(ray, out hit, Mathf.Infinity, allyC.mask))
                            {
                                var obj = hit.transform.gameObject;
                                if (!obj.GetComponent<Base—haracteristic>().isBoss && !obj.GetComponent<Base—haracteristic>().isAlly && bc.curHp > obj.GetComponent<Base—haracteristic>().curHp)
                                {
                                    Next(obj, true);
                                }
                            }
                        }
                        break;
                    case "ai":
                        switch (bc.isAlly)
                        {
                            case true:
                                var v = Random.Range(0, enemyC.allEnemyCharacters.Count - 1);
                                if (bc.curHp > enemyC.allEnemyCharacters[v].GetComponent<Base—haracteristic>().curHp)
                                {
                                    Next(enemyC.allEnemyCharacters[v], true);
                                }
                                break;
                            case false:
                                var z = Random.Range(0, allyC.allAllyCharacters.Count - 1);
                                if (bc.curHp > allyC.allAllyCharacters[z].GetComponent<Base—haracteristic>().curHp)
                                    Next(allyC.allAllyCharacters[z], false);
                                break;
                        }
                        break;
                }
            }
        }
        catch { }
    }
    void Next(GameObject obj, bool ally)
    {
        switch (ally)
        {
            case true:
                enemyC.allEnemyCharacters.Remove(obj);
                allyC.allAllyCharacters.Add(obj);
                obj.GetComponent<Base—haracteristic>().isAlly = ally;
                obj.GetComponent<MovementChanger>().movement = "mouse";
                obj.GetComponent<MovementChanger>().Next();
                break;
            case false:
                allyC.allAllyCharacters.Remove(obj);
                enemyC.allEnemyCharacters.Add(obj);
                obj.GetComponent<Base—haracteristic>().isAlly = ally;
                obj.GetComponent<MovementChanger>().movement = "ai";
                obj.GetComponent<MovementChanger>().Next();
                break;
        }
        player.GetComponent<Animator>().SetTrigger("cast");
        manager.ChangeCursor(manager.defaultCursor);
        bc.isCast = false;
        active = false;
    }
}