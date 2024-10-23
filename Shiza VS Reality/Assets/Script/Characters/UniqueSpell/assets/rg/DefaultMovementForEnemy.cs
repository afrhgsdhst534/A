using UnityEngine;
using UnityEngine.AI;
using System.Threading.Tasks;
public class DefaultMovementForEnemy : MonoBehaviour
{
    private NavMeshAgent agent;
    public Transform player;
    public AllyCharacters ally;
    private Vector3 vec;
    private float curTime = 2;
    public int number = 1;
    private MeshRenderer mesh;
    public RacoonBodyObj obj;
    public Vector3 vector;
    private void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        ally = AllyCharacters.instance;
        mesh = GetComponent<MeshRenderer>();
        transform.LookAt(ally.allAllyCharacters[0].transform.position);
        switch (number)
        {
            case 1:
                OnBlue();
                break;
            case 2:
                gameObject.GetComponent<Rigidbody>().isKinematic = false;
                Next();
                break;
            case 3:
                if (obj.hp < 3)
                    obj.hp++;
                break;
            case 4:
                if (obj.hp > 1)
                    obj.hp--;
                break;
        }
    }
    async void Next()
    {
        transform.LookAt(vector);
        await Task.Delay(200);
        gameObject.GetComponent<Rigidbody>().AddForce((ally.allAllyCharacters[0].transform.position - transform.position) * 200, ForceMode.Force);
    }
    void Update()
    {
        switch (number)
        {
            //blue
            case 1:
                curTime -= Time.deltaTime;
                if (curTime <= 0)
                {
                    vec = ally.allAllyCharacters[0].transform.position;
                    agent.SetDestination(vec);
                    float f = Vector3.Distance(vec, transform.position);
                    if (f < 2.5f)
                    {
                        agent.speed = 8;
                        mesh.enabled = true;
                    }
                    else
                    {
                        agent.speed = 15;
                        mesh.enabled = false;
                    }
                }
                break;
            //oragnge
            case 2:
                vec = ally.allAllyCharacters[0].transform.position;
                float nef = Vector3.Distance(vec, transform.position);
                agent.speed = 33;

                if (nef > 3)
                {

                    agent.SetDestination(vec);
                }
                else
                {

                    agent.SetDestination(-vec);
                }
                break;
            //pink
            case 3:
                curTime -= Time.deltaTime;
                if (curTime <= 0)
                {
                    Pink();
                }
                break;
            //red
            case 4:
                vec = ally.allAllyCharacters[0].transform.position;
                agent.SetDestination(vec);
                break;
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj.hp--;
        }
    }
    void Pink()
    {
        int a = Random.Range(1, 4);
        switch (a)
        {
            case 1:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x - 2, 1, ally.allAllyCharacters[0].transform.position.z - 2);
                transform.position = vec;
                curTime = 3;
                break;
            case 2:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x - 2, 1, ally.allAllyCharacters[0].transform.position.z + 2);
                transform.position = vec;
                curTime = 3;
                break;
            case 3:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x + 2, 1, ally.allAllyCharacters[0].transform.position.z - 2);
                transform.position = vec;
                curTime = 3;
                break;
            case 4:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x + 2, 1, ally.allAllyCharacters[0].transform.position.z + 2);
                transform.position = vec;
                curTime = 3;
                break;
        }
        curTime = 3;
    }
    void OnBlue()
    {
        int a = Random.Range(1, 4);
        switch (a)
        {
            case 1:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x, 1, ally.allAllyCharacters[0].transform.position.z - 2);
                transform.position = vec;
                curTime = 3;
                break;
            case 2:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x, 1, ally.allAllyCharacters[0].transform.position.z + 2);
                transform.position = vec;
                curTime = 3;
                break;
            case 3:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x + 2, 1, ally.allAllyCharacters[0].transform.position.z);
                transform.position = vec;
                curTime = 3;
                break;
            case 4:
                vec = new Vector3(ally.allAllyCharacters[0].transform.position.x + 2, 1, ally.allAllyCharacters[0].transform.position.z);
                transform.position = vec;
                curTime = 3;
                break;
        }
    }
}