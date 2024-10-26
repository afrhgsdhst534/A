using UnityEngine;
public class HunterInstinct : Spell
{
    private EnemyCharacters enemyC;
    private AllyCharacters allyC;
    Base—haracteristic bc;
    private SpritesManager sm;
    public override void OnAwake(GameObject obj)
    {
        base.OnAwake(obj);
        LvlLimit = 1000;
        bc = player.GetComponent<Base—haracteristic>();
        enemyC = EnemyCharacters.instance;
        allyC = AllyCharacters.instance;
        Buffed(25);
        sm = SpritesManager.instance;
    }
    public override void Cast()
    {
        if (cooldown < 1)
        {
            active = true;
            bc.curMana -= 25;
            bc.isCast = true;
            sm.ChangeCursor(sm.badCursor);
        }
    }
    private void Update()
    {
        if (active)
        {
            switch (player.GetComponent<MovementChanger>().movement)
            {
                case "arrow":
                case "mouse":
                    if (Input.GetMouseButtonDown(0))
                    {
                        var cam = Camera.main;
                        Ray ray = cam.ScreenPointToRay(Input.mousePosition);
                        RaycastHit hit;
                        if (Physics.Raycast(ray, out hit, Mathf.Infinity, allyC.mask))
                        {
                            Next(hit.transform);
                        }
                    }
                    break;
                case "ai":
                    switch (bc.isAlly)
                    {
                        case true:
                            var v = Random.Range(0, enemyC.allEnemyCharacters.Count-1);
                            Next(enemyC.allEnemyCharacters[v].transform);
                            break;
                        case false:
                            var z = Random.Range(0, allyC.allAllyCharacters.Count - 1);
                            Next(allyC.allAllyCharacters[z].transform);
                            break;
                    }
                    break;
            }
        }
    }
    void Next(Transform trans)
    {
        player.GetComponent<Animator>().SetTrigger("cast");
        var obj = trans.position;
        Vector3 vector = new Vector3(obj.x, obj.y, obj.z - 1);
        player.transform.position = vector;
        trans.GetComponent<Base—haracteristic>().DamageCalculations(bc.magicDamage, "magical");
        if (trans.GetComponent<Base—haracteristic>().curHp <= trans.GetComponent<Base—haracteristic>().maxHp / 2)
        {
            trans.GetComponent<Base—haracteristic>().DamageCalculations(bc.magicDamage, "magical");
        }
        cooldown += 12-value;
        sm.ChangeCursor(sm.defaultCursor);
        bc.isCast = false;
        active = false;
    }
    public override void Up()
    {
        base.Up();
        Buffed(1);
    }
    void Buffed(int value)
    {
        bc.speed += value;
        bc.attack += value;
    }
}