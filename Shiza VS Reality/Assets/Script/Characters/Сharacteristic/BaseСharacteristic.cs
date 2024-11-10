using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
[SelectionBase]
public class BaseСharacteristic : MonoBehaviour
{
    public float negativeAttack;
    #region vars
    [Space]
    [Header("Stats")]
    [Space]
    public int speed;
    public int curMana;
    public int maxMana;
    public int magicResist;
    public int hpRegen;
    public int armour;
    public int curHp;
    public int maxHp;
    public int attack;
    public int magicDamage;
    public int attackSpeed;
    public int manaRegen;
    [Space]
    public int money;
    public int moneyPerSecond;
    [Space]
    [Header("Other")]
    [Space]
    public int attackRange;
    [Space]
    [Header("Bools")]
    [Space]
    public bool isAlly = false;
    public bool isAttacking = false;
    public bool canMove = true;
    public bool isBoss = false;
    public bool isCast = false;
    [Space]
    [Header("LVL")]
    [Space]
    public int curLvl;
    public int maxLvl;
    public int lvlPoints;
    private CanvasManager canvasManager;
    public List<GameObject> targets;
    [HideInInspector]
    public Action onLvlUp;
    private AllyCharacters ally;
    private EnemyCharacters enemy;
    public bool immortal;
    #endregion
    private void Start()
    {
        canvasManager = CanvasManager.instance;
        ally = AllyCharacters.instance;
        enemy = EnemyCharacters.instance;
    }
    public void LvlUp()
    {
        curLvl -= maxLvl;
        maxLvl += 25;
        speed += 1;
        curMana += 11;
        maxMana += 11;
        magicResist += 11;
        hpRegen+=5;
        manaRegen+=5;
        armour += 11;
        curHp += 50;
        maxHp += 50;
        attack += 11;
        magicDamage += 11;
        money += 150;
        lvlPoints++;
        onLvlUp?.Invoke();
    }
    public void DamageCalculations(int damage, string type)
    {
        switch (type)
        {
            case "physical":
                if (damage > armour) { curHp -= damage - armour; canvasManager.Popup(damage - armour, gameObject); }
                else { curHp -= hpRegen / 2; canvasManager.Popup(hpRegen / 2, gameObject); }
                break;
            case "magical":
                if (damage > armour) { curHp -= damage - magicResist; canvasManager.Popup(damage - magicResist, gameObject); }
                else { curHp -= hpRegen / 2; canvasManager.Popup(hpRegen / 2, gameObject); }
                break;
            case "true":
                if (damage < 0)
                {
                    negativeAttack += damage;
                }
                if (negativeAttack <= -10000)
                {
                    PlayerPrefs.SetInt("invite3", 1);
                }
                curHp -= damage;
                canvasManager.Popup(damage, gameObject);
                break;
            default: curHp -= damage;
                canvasManager.Popup(damage, gameObject);
                break;
        }
        if (curHp < 1)
        {
            StartCoroutine(Death());
        }
    }
    IEnumerator Death()
    {
        if (immortal)
        {
            curHp = maxHp;
            immortal = false;
        }
        else
        {
            GetComponent<BaseСharacteristic>().enabled = false;
            GetComponent<Attack>().enabled = false;
            GetComponent<ArrowMovement>().enabled = false;
            GetComponent<MouseMovement>().enabled = false;
            GetComponent<MinionsMovement>().enabled = false;
            GetComponent<NavMeshAgent>().enabled = false;
            GetComponent<Collider>().enabled = false;
            GetComponent<Rigidbody>().isKinematic = true;
            yield return new WaitForSeconds(0.1f);
            switch (isAlly)
            {
                case true:
                    for (int i = 0; i < enemy.allEnemyCharacters.Count; i++)
                    {
                        enemy.allEnemyCharacters[i].GetComponent<BaseСharacteristic>().curLvl += (maxLvl/2) / enemy.allEnemyCharacters.Count + 1;
                    }
                    break;
                case false:
                    for (int i = 0; i < ally.allAllyCharacters.Count; i++)
                    {
                        ally.allAllyCharacters[i].GetComponent<BaseСharacteristic>().curLvl += (maxLvl/2) / ally.allAllyCharacters.Count + 1;
                    }
                    break;
            }
            Destroy(gameObject, 1);
            var animator = gameObject.GetComponent<Animator>();
            animator.SetTrigger("death");
        }
    }
}