using UnityEngine;
using Lean.Localization;
using System.Threading.Tasks;
using System.Collections.Generic;
public class Training : MonoBehaviour
{
    AllyCharacters ally;
    public GameObject player;
    public float time;
    float curTime;
    public bool start = false;
    const string path = "Sphere";
    public List<GameObject> chars;
    public Material mat;
    public static Training a;
    public int lvl;
    public int stringI;
    public LeanLocalizedText text;
    public GameObject but;
    public GameObject but1;
    public GameObject[] objs;
    public IAttackObject ao;
    public AttackModificatior mod;
    public GameObject[] allToDestr;
    public  float bossTime = 40;
    public GameObject boss;
    public Portals portal;
    public AudioSource source;
    public Light l;
    public Spell[] spells;
    public IAttackObject attackObj;
    private void OnDisable() => portal.onTeleport -= OnTeleport;
    private void Awake()
    {
        portal.onTeleport += OnTeleport;
        a = this; for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(true);
        }
    }
    private void Start()
    {
        ally = AllyCharacters.instance;
        ally.allAllyCharacters.Add(player);
        Asynk();
    }
    void OnTeleport()
    {
        source.Stop();
    }
    async void Asynk()
    {
        await Task.Delay(10);
        ally.allAllyCharacters[0].SetActive(true);
        ally.allAllyCharacters[0].GetComponent<Attack>().AttackObjChanger(ao);
        ally.allAllyCharacters[0].GetComponent<Attack>().AddModificator(mod);
    }
    private void Update()
    {
        if (allToDestr[1] == null)
        {
            bossTime -= Time.deltaTime;
        }
        if (bossTime <= 0)
        {
            boss.SetActive(true);
            l.gameObject.SetActive(false);
        }
        if (ally.allAllyCharacters.Count >= 1)
        {
            curTime -= Time.deltaTime;
            if (curTime <= 0 && start)
            {
                lvl += 50;
                Spawn();
                curTime = time;
            }
        }
        if (allToDestr[1] != null)
        {
            switch (stringI)
            {
                case 0:
                    but.SetActive(false);
                    text.TranslationName = "Begin";
                    break;
                case 1:
                    but.SetActive(true);
                    but1.SetActive(true);
                    text.TranslationName = "MovementExplantation";
                    break;
                case 2:
                    but1.SetActive(false);
                    text.TranslationName = "Explantation";
                    break;
            }
        }
    }
    void Spawn()
    {
        int i = UnityEngine.Random.Range(1, 5);
        switch (i)
        {
            case 1:
                Next(-23f, true);
                break;
            case 2:
                Next(23f, false);
                break;
            case 3:
                Next(-23f, false);
                break;
            case 4:
                Next(23f, true);
                break;
        }
    }
    void Next(float f, bool b)
    {
        if (b)
        {
            var a = Instantiate(Resources.Load<GameObject>(path));
            a.transform.position = new Vector3(f, 0.3f, 0);
            a.transform.LookAt(ally.allAllyCharacters[0].transform);
            a.GetComponent<Rigidbody>().AddForce(a.transform.forward * 444);
            a.AddComponent<TrainingCharacters>();
        }
        else
        {
            var a = Instantiate(Resources.Load<GameObject>(path));
            a.transform.position = new Vector3(0, 0.3f, f);
            a.transform.LookAt(ally.allAllyCharacters[0].transform);
            a.GetComponent<Rigidbody>().AddForce(a.transform.forward * 444);
            a.AddComponent<TrainingCharacters>();
        }
    }
    public void Nexti()
    {
        stringI++;
    }
    public void Previous()
    {
        stringI--;
    }
}