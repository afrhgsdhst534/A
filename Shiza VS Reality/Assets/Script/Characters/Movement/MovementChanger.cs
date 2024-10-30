using UnityEngine;
using UnityEngine.AI;
public class MovementChanger : MonoBehaviour
{
    public string movement;
    private ArrowMovement arrow;
    private MouseMovement mouse;
    private MinionsMovement ai;
    private NavMeshAgent agent;
    private BaseÑharacteristic chars;
    private AllyCharacters allyCharacters;
    private EnemyCharacters enemyCharacters;
    private Rigidbody rb;
    private CapsuleCollider capsule;
    private void Start()
    {
        Next();
    }
    [ContextMenu("MovementChanger")]
    public void Next()
    {
        allyCharacters = AllyCharacters.instance;
        enemyCharacters = EnemyCharacters.instance;
        chars ??= GetComponent<BaseÑharacteristic>();
        //if char is ally
        if (chars.isAlly && !allyCharacters.allAllyCharacters.Contains(gameObject))
        {
            allyCharacters.allAllyCharacters.Add(gameObject);
        }
        //if char is enemy
        if (!chars.isAlly && !enemyCharacters.allEnemyCharacters.Contains(gameObject))
        {
            enemyCharacters.allEnemyCharacters.Add(gameObject);
        }
        if ((gameObject.GetComponent("ArrowMovement") as ArrowMovement) != null)
        {
            arrow = GetComponent<ArrowMovement>();
        }
        if ((gameObject.GetComponent("MinionsMovement") as MinionsMovement) != null)
        {
            ai = GetComponent<MinionsMovement>();
        }
        if ((gameObject.GetComponent("NavMeshAgent") as NavMeshAgent) != null)
        {
            agent = GetComponent<NavMeshAgent>();
        }
        if ((gameObject.GetComponent("MouseMovement") as MouseMovement) != null)
        {
            mouse = GetComponent<MouseMovement>();
        }
        if ((gameObject.GetComponent("Rigidbody") as Rigidbody) != null)
        {
            rb = GetComponent<Rigidbody>();
        }
        if ((gameObject.GetComponent("CapsuleCollider") as CapsuleCollider) != null)
        {
            capsule = GetComponent<CapsuleCollider>();
        }
        switch (movement)
        {
            case "arrow":
                if (arrow != null)
                {
                    Arrow();
                }
                else
                {
                    print($"{gameObject.name}" + "MovementChanger.arrow is null");
                }
                break;
            case "mouse":
                if (mouse != null)
                {
                    Mouse();
                }
                else
                {
                    print($"{gameObject.name}" + "MovementChanger.mouse is null");
                }
                break;
            case "ai":
                if (ai != null)
                {
                    AI();
                }
                else
                {
                    print($"{gameObject.name}" + "MovementChanger.ai is null");
                }
                break;
            default:
                print($"{movement}" + $"{gameObject.name}" + " õóéíÿ");
                break;
        }
    }
    public void Arrow()
    {
        arrow.enabled = true;
        mouse.enabled = false;
        ai.enabled = false;
        agent.enabled = false;
        capsule.isTrigger = false;
        rb.constraints = RigidbodyConstraints.FreezeRotationZ | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
        rb.isKinematic = false;
    }
    public void Mouse()
    {
        mouse.enabled = true;
        arrow.enabled = false;
        ai.enabled = false;
        agent.enabled = true;
        capsule.isTrigger = true;
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.isKinematic = false;
    }
    public void AI()
    {
        arrow.enabled = false;
        mouse.enabled = false;
        ai.enabled = true;
        agent.enabled = true;
        capsule.isTrigger = true;
        rb.constraints = RigidbodyConstraints.FreezePositionY | RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationZ;
        rb.isKinematic = false;
    }
    public void OnDestroy()
    {
        if (chars.isAlly && allyCharacters.allAllyCharacters.Contains(gameObject))
        {
            if (allyCharacters.selectedAllyCharacters.Contains(gameObject))
            {
                allyCharacters.selectedAllyCharacters.Remove(gameObject);
                allyCharacters.allAllyCharacters.Remove(gameObject);
            }
            else
            {
                allyCharacters.allAllyCharacters.Remove(gameObject);
            }
        }
        if (!chars.isAlly)
        {
            enemyCharacters.allEnemyCharacters.Remove(gameObject);
        }
    }
}