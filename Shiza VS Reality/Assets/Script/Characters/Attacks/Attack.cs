using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class Attack : MonoBehaviour
{
    public List<AttackModificatior> modificatior;
    public Animator animator;
    public Base—haracteristic chars;
    public float delay;
    public bool attack;
    private MovementChanger changer;
    public IAttackObject attackObject;
    public Action onAttack;
    public GameObject aOObj;
    public Transform mObj;
    private InputButtons mButtons;
    public void Start()
    {
        changer = GetComponent<MovementChanger>();
        animator = GetComponent<Animator>();
        chars = GetComponent<Base—haracteristic>();
        animator = GetComponent<Animator>();
        mButtons = InputButtons.instance;
    }
    private void Update()
    {
        delay -= Time.deltaTime;
        if (Input.GetMouseButtonDown(1) && changer.movement == "arrow" && attackObject != null || changer.movement == "arrow" && Input.GetKeyDown(mButtons.attack))
        {
            Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
            Vector3 dir = Input.mousePosition - pos;
            float angle = Mathf.Atan2(dir.x, dir.y) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.up);
            StartCoroutine(OnAttack());
        }
        if (attack && chars.isAttacking && changer.movement == "ai" && attackObject != null)
        {
            StartCoroutine(OnAttackEnemy());
        }
        switch (delay)
        {
            case < 0:
                attack = true;
                break;
            case > 0:
                attack = false;
                break;
        }
    }
    public void AddModificator(AttackModificatior m)
    {
        var a = Instantiate(m);
        modificatior.Add(a);
        a.transform.SetParent(mObj);
        a.transform.localScale = Vector3.one;
    }
    public void AttackObjChanger(IAttackObject obj)
    {
        attackObject = obj;
        var a = Instantiate(obj.attackObj);
        if (aOObj.transform.childCount > 0)
        {
            DestroyImmediate(aOObj.transform.GetChild(0).gameObject);
        }
        a.transform.SetParent(aOObj.transform);
        a.transform.localScale = Vector3.one;
    }
    public IEnumerator OnAttackEnemy()
    {
        if (modificatior != null)
        {
            Next();
            yield return new WaitForSeconds(delay);
            chars.canMove = true;
            animator.SetBool("attackB", false);
            chars.isAttacking = false;
        }
    }
    public IEnumerator OnAttack()
    {
        if (attack && chars.isAlly && attackObject != null || attack && changer.movement == "arrow" && attackObject != null)
        {
            Next();
            yield return new WaitForSeconds(delay);
            animator.SetBool("attackB", false);
            chars.isAttacking = false;

        }
    }
    void Next()
    {
        if (attackObject != null)
        {
            chars.isAttacking = true;
            animator.SetBool("attackB", true);
            animator.SetFloat("attackF", 1 + (chars.attackSpeed / 100f));
            attackObject.bc = chars;
            attackObject.trans = transform;
            var m = Instantiate(attackObject.gameObject);
            m.GetComponent<IAttackObject>().isAlly = chars.isAlly;
            if (modificatior != null)
            {
                for (int i = 0; i < modificatior.Count; i++)
                {
                    modificatior[i].chars = chars;
                    modificatior[i].obj = m;
                    modificatior[i].Spawn();
                }
            }
            delay = 1 - (chars.attackSpeed / 100f);
            onAttack?.Invoke();
        }
    }
}