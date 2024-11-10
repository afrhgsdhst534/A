using UnityEngine;
using UnityEngine.UI;
public class PlayersUIManager : MonoBehaviour
{
    public GameObject canvas;
    private CanvasManager manager;
    public GameObject statsObj;
    public Text charactersStatsDamage;
    public Text charactersStatsAR;
    public Text charactersStatsAS;
    public Text charactersStatsSpeed;
    public Text charactersStatsMagicDamage;
    public Text charactersStatsMagicR;
    public Text charactersStatsArmour;
    public Text money;
    public Text statsName;
    public Transform spells;
    Base—haracteristic chars;
    public Slider hp;
    public Slider mana;
    public Slider exp;
    public Text tMana;
    public Text tMMana;
    public Text tHp;
    public Text tMHp;
    public Text hpRegen;
    public Text manaRegen;
    public Text lvlCount;
    private float time = 1;
    private float curTime;
    private void Start()
    {
        manager = CanvasManager.instance;
        chars = GetComponent<Base—haracteristic>();
        time = 1;
        curTime = 0;
    }
    public void Update()
    {
        if (manager.pickedChar==gameObject)
        {
            canvas.SetActive(true);
        }
        else
        {
            canvas.SetActive(false);
        }
        if (statsObj.activeInHierarchy)
        {
            charactersStatsDamage.text = chars.attack.ToString();
            charactersStatsAR.text = chars.attackRange.ToString();
            charactersStatsAS.text = chars.attackSpeed.ToString();
            charactersStatsSpeed.text = chars.speed.ToString();
            charactersStatsMagicDamage.text = chars.magicDamage.ToString();
            charactersStatsMagicR.text = chars.magicResist.ToString();
            charactersStatsArmour.text = chars.armour.ToString();
            money.text = chars.money.ToString();
        }
        if (manager.pickedChar == gameObject)
        {
            tMana.text = chars.curMana.ToString();
            tMMana.text = chars.maxMana.ToString();
            tHp.text = chars.curHp.ToString();
            tMHp.text = chars.maxHp.ToString();
            hpRegen.text = chars.hpRegen.ToString();
            manaRegen.text = chars.manaRegen.ToString();
            statsName.text = transform.gameObject.name;
            exp.maxValue = chars.maxLvl;
            exp.value = chars.curLvl;
        }
        curTime += Time.deltaTime;
        if(curTime >= time)
        {
            chars.curHp += chars.hpRegen;
            chars.curMana += chars.manaRegen;
            chars.money += chars.moneyPerSecond;
            curTime = 0;
        }
        if (chars.maxHp<chars.curHp)
        {
            chars.curHp = chars.maxHp;
        }
        if (chars.maxMana < chars.curMana)
        {
            chars.curMana = chars.maxMana;
        }
        if (chars.speed>300)
        {
            chars.speed = 300;
        }
        if (chars.attackSpeed > 100)
        {
            chars.attackSpeed = 100;
        }
        if (chars.curLvl>=chars.maxLvl)
        {
            int a = int.Parse(lvlCount.text);
            a++;
            lvlCount.text = a.ToString();
            chars.LvlUp();
            var move = GetComponent<RelativeObjs>();
            move.OnLvlUp();
        }
    }
    public void Show()
    {
        statsObj.SetActive(!statsObj.activeInHierarchy);
    }
}