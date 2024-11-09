using UnityEngine;
using System.Collections;
using UnityEngine.AI;
public abstract class BaseMovement : MonoBehaviour
{
    protected Rigidbody rb;
    protected float speed = 1;
    protected Base—haracteristic chars;
    protected Animator animator;
    protected AllyCharacters allyCharacters;
    [HideInInspector]
    public NavMeshAgent agent;
    protected EnemyCharacters enemys;
    protected Attack attack;
    public virtual void Start()
    {
        rb = GetComponent<Rigidbody>();
        attack = GetComponent<Attack>();
        agent = GetComponent<NavMeshAgent>();
        chars = GetComponent<Base—haracteristic>();
        animator = GetComponent<Animator>();
        allyCharacters = AllyCharacters.instance;
        enemys = EnemyCharacters.instance;
        StartCoroutine(Check());
    }
    public virtual IEnumerator Check()
    {
        yield return new WaitForSeconds(0.35f);
        chars ??= GetComponent<Base—haracteristic>();
        animator ??= GetComponent<Animator>();
        speed = 1 + (chars.speed / 100f);
        animator.SetFloat("walkF", speed);
        StartCoroutine(Check());
    }
    private void OnEnable()
    {
        StartCoroutine(Check());
    }
}