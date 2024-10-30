using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;
public class AllAttackObjList : MonoBehaviour
{
    public List<IAttackObject> allObj;
    public List<Image> childrens;
    public Attack attack;
    private void OnEnable()
    {
        childrens.Clear();
        for (int i = 0; i < allObj.Count; i++)
        {
            var temp = allObj[i];
            int rand = Random.Range(i, allObj.Count);
            allObj[i] = allObj[rand];
            allObj[rand] = temp;
        }
        var a = transform.GetComponentsInChildren<Image>();
        for (int i = 0; i < a.Length; i++)
        {
            childrens.Add(a[i]);
            childrens[i].GetComponentInChildren<LeanLocalizedText>().TranslationName=allObj[i].attackObj.GetComponentInChildren<LeanLocalizedText>().TranslationName;
            childrens[i].GetComponent<Image>().sprite = allObj[i].attackObj.GetComponent<Image>().sprite;
        }
    }
    public void Next()
    {
        attack = CanvasManager.instance.pickedChar.GetComponent<Attack>();
        attack.AttackObjChanger(allObj[0]);
        gameObject.SetActive(false);
    }
    public void Next1()
    {
        attack = CanvasManager.instance.pickedChar.GetComponent<Attack>();
        attack.AttackObjChanger(allObj[1]);
        gameObject.SetActive(false);
    }
    public void Next2()
    {
        attack = CanvasManager.instance.pickedChar.GetComponent<Attack>();
        attack.AttackObjChanger(allObj[2]);
        gameObject.SetActive(false);
    }
}