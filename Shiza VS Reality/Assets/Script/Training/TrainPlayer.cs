using UnityEngine;
using System.Threading.Tasks;
public class TrainPlayer : MonoBehaviour
{
    public float power;
    Animator animator;
    CanvasManager can;
    public Light l;
    bool b;
    public AudioSource source;
    Training tr;
    private void Start()
    {
        tr = Training.a;
        can = CanvasManager.instance;
        animator = GetComponent<Animator>(); GetComponent<Collider>().isTrigger = true;
        GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
    }
    private void Update()
    {
        if (b)
            l.color = new Color(l.color.r, l.color.g - 0.4f, l.color.b - 0.4f);
    }
    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.GetComponent<RelativeObjs>())
        {
            b = true;
            tr.start = true;
            Asynk(collision.gameObject);
        }
    }
    async void Asynk(GameObject obj)
    {
        animator.SetTrigger("A");
        gameObject.GetComponent<ArrowMovement>().enabled = false;
        obj.transform.LookAt(obj.transform);
        gameObject.GetComponent<Rigidbody>().AddForce((obj.transform.position - transform.position) * power, ForceMode.Force);
        for (int i = 0; i < tr.allToDestr.Length; i++)
        {
            Destroy(tr.allToDestr[i]);
        }
        await Task.Delay(850);
        source.Play();
        can.PickedChar(obj);
        can.canvasObject.SetActive(true);
        obj.GetComponent<MovementChanger>().enabled = true;
        obj.GetComponent<MovementChanger>().Next();
        Destroy(gameObject);
        var a = GetComponent<BaseÑharacteristic>();
        var b = obj.GetComponent<BaseÑharacteristic>();
        b.speed += a.speed;
        b.maxMana += a.maxMana;
        b.magicResist += a.magicResist;
        b.hpRegen += a.hpRegen;
        b.armour += a.armour;
        b.maxHp += a.maxHp;
        b.attack += a.attack;
        b.magicDamage += a.magicDamage;
        b.attackSpeed += a.attackSpeed;
        b.manaRegen += a.manaRegen;
        b.attackRange += a.attackRange;
        obj.GetComponent<Attack>().AttackObjChanger(gameObject.GetComponent<Attack>().attackObject);
        for (int i = 0; i < gameObject.GetComponent<Attack>().modificatior.Count; i++)
        {
            obj.GetComponent<Attack>().AddModificator(gameObject.GetComponent<Attack>().modificatior[i]);
        }
    }
}