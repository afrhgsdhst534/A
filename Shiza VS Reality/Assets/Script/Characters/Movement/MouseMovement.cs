using UnityEngine;
using UnityEngine.AI;
using System;
using System.Collections;
public class MouseMovement : BaseMovement
{
    RaycastHit hit;
    Vector3 coordinates;
    bool atack;
    bool walk;
    InputButtons buttons;
    Transform target;
    float x=>transform.position.x;
    float z=> transform.position.z;
    public override void Start()
    {
        base.Start();
        agent = GetComponent<NavMeshAgent>();
        buttons = InputButtons.instance;
    }
    IEnumerator SelectAlly()
    {
        yield return new WaitForSeconds(0.01f);
        allyCharacters.selectedAllyCharacters.Add(gameObject);
        allyCharacters.VisualCreate(gameObject);
    }
    IEnumerator DeselectAlly()
    {
        yield return new WaitForSeconds(0.01f);
        var a = 0;
        for (int i = 0; i < allyCharacters.selectedAllyCharacters.Count; i++)
        {
            if (allyCharacters.selectedAllyCharacters[i] == gameObject)
            {
                a = i;
            }
        }
        Destroy(allyCharacters.allVisual[a]);
        allyCharacters.allVisual.RemoveAt(a);
        allyCharacters.selectedAllyCharacters.Remove(gameObject);
    }
    public void Update()
    {
        agent.speed = speed;
        if (Input.GetKeyDown(KeyCode.Delete)|| Input.GetKeyDown(KeyCode.Tab))
        {
            allyCharacters.RemoveAll();
            enemys.RemoveAll();
        }
        if (Input.GetMouseButtonDown(0)&&!chars.isCast)
        {
            var cam = Camera.main;
            Ray ray = cam.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            if (Physics.Raycast(ray, out hit, Mathf.Infinity, allyCharacters.mask))
            {
                if (chars.isAlly && !allyCharacters.selectedAllyCharacters.Contains(gameObject) && hit.transform.gameObject.name==gameObject.name)
                {
                    StartCoroutine(SelectAlly());
                }
                else if(allyCharacters.selectedAllyCharacters.Contains(gameObject) && hit.transform.gameObject.name == gameObject.name)
                {
                    StartCoroutine(DeselectAlly());
                }
            }
        }
        if (Input.GetMouseButtonDown(1) && chars.canMove&&enabled)
        {
            if (GetComponent<NavMeshAgent>().enabled)
            {
                Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                if (allyCharacters.selectedAllyCharacters.Contains(gameObject) && chars.isAlly)
                {
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, allyCharacters.ground))
                    {
                        walk = true;
                        atack = false;
                        Walk();
                        coordinates = hit.point;
                        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                        Vector3 dir = Input.mousePosition - pos;
                        float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                        transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                    }
                    if (Physics.Raycast(ray, out hit, Mathf.Infinity, enemys.mask))
                    {
                        target = hit.transform;
                        walk = false;
                        atack = true;
                        agent.SetDestination(this.target.position);
                    }
                }
            }
        }
        if (Input.GetKeyDown(KeyCode.LeftAlt))
        {
            allyCharacters.RemoveAll();
            enemys.RemoveAll();
        }
        WalkAnim();
        Attack();
        if (Input.GetKeyDown(buttons.attack))
        {
            this.chars.isAttacking = true;
            attack.StartCoroutine(attack.OnAttack());
        }
    }
    void OnTriggerStay(Collider other)
    {
        if (other.gameObject.GetComponent<Base—haracteristic>() != null)
        {
            if (other.gameObject.CompareTag("Player") && other.gameObject.GetComponent<Base—haracteristic>().isAlly == false && this.enabled == true)
            {
                if (attack.attackObject != null)
                    transform.LookAt(other.transform);
                attack.StartCoroutine(attack.OnAttack());
            }
        }
    }
    void Walk()
    {
        if (walk &&!atack && GetComponent<NavMeshAgent>().enabled)
        {
            agent.SetDestination(hit.point);
        }
    }
    void Attack()
    {
        try
        {
            if (atack && !walk && hit.transform.gameObject != null)
            {
                GameObject target = hit.transform.gameObject;
                coordinates = hit.point;
                if (allyCharacters.selectedAllyCharacters.Contains(gameObject))
                {
                    Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
                    Vector3 dir = Input.mousePosition - pos;
                    float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
                    transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
                    agent.SetDestination(this.target.position);
                }
                if (target.CompareTag("Player") && target.TryGetComponent(out Base—haracteristic chars))
                {
                    float distance = Vector3.Distance(target.transform.position, transform.position);
                    float attackRange = this.chars.attackRange / 10;
                    if (distance < attackRange && target.transform != transform&&attack.attackObject!=null)
                    {
                        this.chars.isAttacking = true;
                        attack.StartCoroutine(attack.OnAttack());
                        agent.SetDestination(transform.position);
                        animator.SetBool("attackB", true);
                    }
                }
                else
                {
                    agent.SetDestination(this.target.position);
                }
            }
        }
        catch { }
    }
    void WalkAnim()
    {
        switch (Math.Round(x, 1) == Math.Round(coordinates.x, 1) && Math.Round(z, 1) == Math.Round(coordinates.z, 1)&&!atack)
        {
            case true:
                    animator.SetBool("walkB", false);
                    walk = false;
                break;
            case false:
                if (agent.enabled)
                    animator.SetBool("walkB", true);
                else
                {
                    animator.SetBool("walkB", false);
                    walk = false;
                }
                break;
        }
    }
}