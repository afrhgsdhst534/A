using UnityEngine;
public class MinionsMovement : BaseMovement
{
    public Transform target;
    private MovementChanger movement;
    SpellManager spells;
    public override void Start()
    {
        base.Start();
        chars.isAttacking = false;
        movement = GetComponent<MovementChanger>();
        var rb = GetComponent<Rigidbody>();
        rb.centerOfMass = Vector3.zero;
        rb.inertiaTensorRotation = Quaternion.identity;
        spells = GetComponent<SpellManager>();
    }
    private void Update()
    {
        #region Move
        switch (this.chars.isAlly && movement.movement == "ai"&&enabled==true)
        {
            case true:
                //if char is ally
                if (enemys.allEnemyCharacters.Count > 0)
                {
                    target = enemys.allEnemyCharacters[0].transform;
                    if (attack.attack)
                    {
                        animator.SetBool("walkB", true);
                        animator.SetBool("attackB", false);
                    }
                }
                else if (enemys.allEnemyCharacters.Count == 0)
                {
                    target = transform;
                    animator.SetBool("walkB", false);
                }
                break;
            case false:
                //if char is enemy
                if (allyCharacters.allAllyCharacters.Count > 0)
                {
                    target = allyCharacters.allAllyCharacters[0].transform;
                    if (attack.attack)
                    {
                        animator.SetBool("walkB", true);
                        animator.SetBool("attackB", false);
                    }
                }
                else if (allyCharacters.allAllyCharacters.Count == 0)
                {
                    target = transform;
                    animator.SetBool("walkB", false);
                }
                break;
        }
        agent.speed = speed;
        if (this.chars.isAttacking && agent.enabled)
        {
            agent.SetDestination(transform.position);
            Rotation();
        }
        else
        {
            if(agent.enabled)
                agent.SetDestination(target.position);
                Rotation();
        }
        if (target.gameObject.CompareTag("Player") && target.gameObject.TryGetComponent(out Base—haracteristic chars))
        {
            float distance = Vector3.Distance(target.position,transform.position);
            float attackRange =  this.chars.attackRange / 10;
            if (distance<attackRange&&target!=transform)
            {
                this.chars.isAttacking = true;
                attack.StartCoroutine(attack.OnAttack());
            }
        }
        #endregion
        for (int i = 0; i < spells.spells.Count; i++)
        {
            if (spells.spells[i].cooldown <= 0)
            {
                spells.spells[i].Cast();
            }
        }
    }
    private void OnTriggerStay(Collider other)
    {

        if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent(out Base—haracteristic chars) && this.enabled == true)
        {
            if (chars.isAlly && !this.chars.isAlly)
            {
                this.chars.isAttacking = true;
                attack.StartCoroutine(attack.OnAttack());
            }
            if (!chars.isAlly && this.chars.isAlly)
            {
                this.chars.isAttacking = true;
                attack.StartCoroutine(attack.OnAttack());
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player") && other.gameObject.TryGetComponent(out Base—haracteristic chars) && enabled == true)
        {
            this.chars.isAttacking = false;
        }
    }
    void Rotation()
    {
        Vector3 dir = (target.transform.position - transform.position).normalized;
        Quaternion lookRot = Quaternion.LookRotation(new Vector3(dir.x, 0, dir.z));
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRot, Time.deltaTime * 5);
    }
}