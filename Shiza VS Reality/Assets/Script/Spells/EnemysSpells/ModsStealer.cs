using UnityEngine;using System.Threading.Tasks;
public class ModsStealer : Spell
{
    public bool b;
    public string movement; AllyCharacters allyC;
    EnemyCharacters enemyC;
    SpritesManager spr;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        allyC = AllyCharacters.instance;
        enemyC = EnemyCharacters.instance;
        LvlLimit = 2;
        spr = SpritesManager.instance;
        passive = true;
    }
    public override void Cast()
    {
        if (cooldown < 1)
        {
            movement = player.GetComponent<MovementChanger>().movement;
            cooldown = 11 - value;
            b = true;
        }
    }
    private async void Update()
    {
        await Task.Delay(1);
        if (b)
        {
            switch (movement)
            {
                case "arrow":
                case "mouse":
                    spr.ChangeCursor(spr.badCursor);
                    if (Input.GetMouseButtonDown(0))
                    {
                        var cam = Camera.main;
                        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity, allyC.mask))
                        {
                            Next(hit.transform.gameObject);
                        }
                    }
                    break;
                case "ai":
                    if (!player.GetComponent<BaseÑharacteristic>().isAlly)
                    {
                        var c = allyC.allAllyCharacters.Count;
                        var r = Random.Range(0, c++);
                        var m = allyC.allAllyCharacters[r].GetComponent<Attack>().modificatior;
                        if (m.Count > 0)
                        {
                            player.GetComponent<Attack>().AddModificator(m[0]);
                            Destroy(m[0].gameObject);
                            m.RemoveAt(0);
                            b = false;
                        }
                    }
                    else
                    {
                        var c = enemyC.allEnemyCharacters.Count;
                        var r = Random.Range(0, c++);
                        var m = enemyC.allEnemyCharacters[r].GetComponent<Attack>().modificatior;
                        if (m.Count > 0)
                        {
                            player.GetComponent<Attack>().AddModificator(m[0]);
                            Destroy(m[0].gameObject);
                            m.RemoveAt(0);
                            b=false;
                        }
                    }
                    break;
            }
        }
    }
    void Next(GameObject obj)
    {
        var m = obj.GetComponent<Attack>().modificatior;
        player.GetComponent<Attack>().AddModificator(m[0]);
        Destroy(m[0].gameObject);
        m.RemoveAt(0);
        spr.ChangeCursor(spr.defaultCursor);
        b = false;
    }
    public override void Up()
    {
        base.Up();
        value++;
    }
}