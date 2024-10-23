using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
public class CanvasManager : MonoBehaviour
{
    public static CanvasManager instance;
    public GameObject prefab;
    private AllyCharacters allyCharacters;
    private EnemyCharacters enemyC;
    public GameObject pickedChar;
    public GameObject canvasObject;
    [HideInInspector]
    public SpellManager spell;
    [HideInInspector]
    public Slider mana;
    [HideInInspector]
    public Slider hp;
    public GameObject hint;
    public Text ht;
    private InputButtons buttons;
    private InventoryManager inventory;
    public InventoryPickUp itemBarrel;
    public List<Item> allItems;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        buttons = InputButtons.instance;
        allyCharacters = AllyCharacters.instance;
        enemyC = EnemyCharacters.instance;
        StartCoroutine(RN());
    }
  public  IEnumerator RN()
    {
        yield return new WaitForSeconds(0.01f);
        if (allyCharacters.allAllyCharacters.Count > 0)
            PickedChar(allyCharacters.allAllyCharacters[0]);
    }
    public void PickedChar(GameObject obj)
    {
        StartCoroutine(D(obj));
    }
    IEnumerator D(GameObject obj)
    {
        yield return new WaitForSeconds(0.01f);
        if (obj.GetComponent<BaseÑharacteristic>() != null)
        {
            if (!obj.GetComponent<BaseÑharacteristic>().isCast)
                pickedChar = obj;
            spell = obj.GetComponent<SpellManager>();
            mana = pickedChar.GetComponent<PlayersUIManager>().mana;
            hp = pickedChar.GetComponent<PlayersUIManager>().hp;
            inventory = pickedChar.GetComponent<InventoryManager>();
        }
    }
    IEnumerator Next1()
    {
        yield return new WaitForSeconds(0.1f);
        allyCharacters.selectedAllyCharacters.Add(allyCharacters.allAllyCharacters[0]);
        allyCharacters.VisualCreate(allyCharacters.allAllyCharacters[0]);
    }
    public void PickCharacter(GameObject obj)
    {
        if (obj.GetComponent<BaseÑharacteristic>() != null)
            if (!obj.GetComponent<BaseÑharacteristic>().isCast)
                pickedChar = obj;
            spell = obj.GetComponent<SpellManager>();
            mana = pickedChar.GetComponent<PlayersUIManager>().mana;
            hp = pickedChar.GetComponent<PlayersUIManager>().hp;
            inventory = pickedChar.GetComponent<InventoryManager>();
    }
    private void Update()
{
        if (Input.GetKeyDown(KeyCode.P)) {
            if (Time.timeScale>0)
            {
                Time.timeScale = 0;
            }
            else { Time.timeScale = 1; }
        }

        if (pickedChar != null && pickedChar.GetComponent<BaseÑharacteristic>() != null)
        {
            if (Input.GetKeyDown(KeyCode.G))
            {
                pickedChar.GetComponent<RelativeObjs>().us.Cast();
            }
            if (pickedChar == null && allyCharacters.allAllyCharacters.Count > 0)
            {
                PickCharacter(allyCharacters.allAllyCharacters[0]);
            }
            if (Input.GetKeyDown(KeyCode.Tab))
            {
                allyCharacters.RemoveAll();
                enemyC.RemoveAll();
                if (pickedChar.GetComponent<MovementChanger>().movement != "arrow")
                {
                    PickedChar(allyCharacters.allAllyCharacters[0]);
                    StartCoroutine(Next1());
                }
            }
            if (Input.GetMouseButtonDown(0))
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                RaycastHit hit;
                if (Physics.Raycast(ray, out hit, Mathf.Infinity, allyCharacters.mask) && !pickedChar.GetComponent<BaseÑharacteristic>().isCast)
                {
                    PickedChar(hit.transform.gameObject);
                }
            }
            if (spell != null && pickedChar != null)
            {
                if (spell.chars.isAlly)
                {
                    try
                    {
                        if (Input.GetKeyDown(buttons.firstSpell))
                        {
                            spell.spells[0].Cast();
                        }
                        if (Input.GetKeyDown(buttons.secondSpell))
                        {
                            spell.spells[1].Cast();
                        }
                        if (Input.GetKeyDown(buttons.thirdSpell))
                        {
                            spell.spells[2].Cast();
                        }
                        if (Input.GetKeyDown(buttons.fourthSpell))
                        {
                            spell.spells[3].Cast();
                        }
                    }
                    catch { }
                }
            }
            try
            {
                if (pickedChar.GetComponent<BaseÑharacteristic>().isAlly && pickedChar != null)
                {
                    if (Input.GetKeyDown(buttons.item1))
                    {
                        inventory.items[0].OnUse();
                    }
                    if (Input.GetKeyDown(buttons.item2))
                    {
                        inventory.items[1].OnUse();
                    }
                    if (Input.GetKeyDown(buttons.item3))
                    {
                        inventory.items[2].OnUse();
                    }
                    if (Input.GetKeyDown(buttons.item4))
                    {
                        inventory.items[3].OnUse();
                    }
                    if (Input.GetKeyDown(buttons.item5))
                    {
                        inventory.items[4].OnUse();
                    }
                    if (Input.GetKeyDown(buttons.item6))
                    {
                        inventory.items[5].OnUse();
                    }
                }
                if (pickedChar != null)
                    Next(pickedChar);
            }
            catch { }
        }
    }
    void Next(GameObject obj)
    {
        mana.maxValue = obj.GetComponent<BaseÑharacteristic>().maxMana;
        mana.value = obj.GetComponent<BaseÑharacteristic>().curMana;
        hp.value = obj.GetComponent<BaseÑharacteristic>().curHp;
        hp.maxValue = obj.GetComponent<BaseÑharacteristic>().maxHp;
    }
    public void Popup(int value, GameObject character)
    {
        GameObject obj = Instantiate(prefab, character.transform.position, prefab.transform.localRotation);
        obj.transform.position += new Vector3(Random.Range(-0.15f, 0.15f), Random.Range(1.7f, 2), Random.Range(-0.15f, 0.15f));
        obj.GetComponent<TextMesh>().text = value.ToString();
        Destroy(obj, 0.3f);
    }
    public void SpellVizualization(Spell spell)
    {
        var SO = pickedChar.GetComponent<PlayersUIManager>().spells;
        GameObject obj = Instantiate(spell.gameObject, SO.transform.position, Quaternion.identity);
        pickedChar.GetComponent<SpellManager>().spells.Add(obj.GetComponent<Spell>());
        obj.GetComponent<Spell>().OnAwake(pickedChar);
        obj.GetComponent<ButtonOnClick>().CheckUp();
        obj.transform.SetParent(SO.transform);
        obj.GetComponent<Image>().sprite = spell.picture;
        obj.GetComponent<ButtonOnClick>().spell = spell;
        obj.transform.localScale = Vector3.one;
        if (pickedChar.GetComponent<BaseÑharacteristic>().isAlly)
        {
            obj.GetComponent<ButtonOnClick>().ally = true;
        }
    }
    public void CreateBarrel(Item item)
    {
        var barrel = Instantiate(itemBarrel);
        barrel.item = item;
        item.gameObject.SetActive(false);
        var a = pickedChar.transform.position;
        barrel.transform.position = new Vector3(a.x + Random.Range(0.8f, 1.5f), a.y, a.z + Random.Range(0.8f, 1.5f));
    }
}