using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;
public class AllRelativeAttack : MonoBehaviour
{
    private AllyCharacters chars;
    private GameObject player;
    private CanvasManager canvasManager;
    private List<Transform> childs;
    private void OnEnable()
    {
        var b   = gameObject.transform.GetComponentsInChildren<Transform>();
        childs = b.OfType<Transform>().ToList();
        childs.Remove(transform);
        childs.Remove(transform);
        for (int i = 0; i < b.Length; i++)
        {
            if (b[i].TryGetComponent(out Text text))
            {
                childs.Remove((Transform)b[i]);
            }
        }
        canvasManager = CanvasManager.instance;
        chars = AllyCharacters.instance;
        player = chars.allAllyCharacters[0];
        childs[0].GetComponent<Image>().sprite = player.GetComponent<RelativeObjs>().attackObj.attackObj.GetComponent<Image>().sprite;
        childs[1].GetComponent<Image>().sprite = player.GetComponent<RelativeObjs>().attackMods[0].GetComponent<Image>().sprite;
        childs[2].GetComponent<Image>().sprite = player.GetComponent<RelativeObjs>().attackMods[1].GetComponent<Image>().sprite;
        var c = player.GetComponent<RelativeObjs>().attackObj;
        var d = player.GetComponent<RelativeObjs>().attackMods.ElementAtOrDefault(0);
        var e = player.GetComponent<RelativeObjs>().attackMods.ElementAtOrDefault(1);
        childs[0].GetComponentInChildren<LeanLocalizedText>().TranslationName = c.name;
        childs[1].GetComponentInChildren<LeanLocalizedText>().TranslationName = d.name;
        childs[2].GetComponentInChildren<LeanLocalizedText>().TranslationName = e.name;
    }
    public void AddAttack()
    {
        var p = canvasManager.pickedChar.GetComponent<Attack>();
        p.AttackObjChanger(player.GetComponent<RelativeObjs>().attackObj);
        transform.gameObject.SetActive(false);
    }
    public void AddMod()
    {
        var p = canvasManager.pickedChar.GetComponent<Attack>();
        p.AddModificator(player.GetComponent<RelativeObjs>().attackMods[0]);
        transform.gameObject.SetActive(false);
    }
    public void AddMod1()
    {
        var p = canvasManager.pickedChar.GetComponent<Attack>();
        p.AddModificator(player.GetComponent<RelativeObjs>().attackMods[1]);
        transform.gameObject.SetActive(false);
    }
}