using UnityEngine;using System.Threading.Tasks;
public class YouAreMine : Spell
{
    public SpritesManager manager;
    public AllyCharacters allyC;
    public EnemyCharacters enemyC;
  public  MovementChanger mc;
    public Base—haracteristic bc;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
    }
    public override void Cast()
    {
        mc = player.GetComponent<MovementChanger>();
        bc = player.GetComponent<Base—haracteristic>();
        manager = SpritesManager.instance;
        allyC = AllyCharacters.instance;
        enemyC = EnemyCharacters.instance;
        if (bc.curMana >= bc.maxMana)
        {
            active = true;
        }
    }
    public  void Update()
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
                                print(1);
                                var obj = hit.transform.gameObject;
                                if (!obj.GetComponent<Base—haracteristic>().isBoss && !obj.GetComponent<Base—haracteristic>().isAlly)
                                {
                                    Next(obj, true);
                                }
                            }
                        }
                        break;
                     default:
                        break;
                }
            }
        }
        catch { }
    }
    async void Next(GameObject obj, bool ally)
    {
        print(1);
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
        cost = 600 - value * 5;
        cooldown = 10;
        PlayerPrefs.SetInt("invite8", 1);
        bc.isCast = false;
        bc.curMana -= 100;
        active = false;
        await Task.Delay(1);
    }
}