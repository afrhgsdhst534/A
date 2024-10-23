using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using Lean.Localization;
using UnityEngine.UI;
public class AllRelativeSpells : MonoBehaviour
{
    private AllyCharacters chars;
    private GameObject player;
    private CanvasManager canvasManager;
    private List<Transform> childs;
    private void OnEnable()
    {
        canvasManager = CanvasManager.instance;
        chars = AllyCharacters.instance;
        var b = gameObject.transform.GetComponentsInChildren<Transform>();
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
        player = chars.allAllyCharacters[0];
        childs[0].GetComponent<Image>().sprite = player.GetComponent<RelativeObjs>().spells[0].picture;
        childs[1].GetComponent<Image>().sprite = player.GetComponent<RelativeObjs>().spells[1].picture;
        childs[2].GetComponent<Image>().sprite = player.GetComponent<RelativeObjs>().spells[2].picture;
        childs[3].GetComponent<Image>().sprite = player.GetComponent<RelativeObjs>().spells[3].picture;

        var c = player.GetComponent<RelativeObjs>().spells.ElementAtOrDefault(0);
        var d = player.GetComponent<RelativeObjs>().spells.ElementAtOrDefault(1);
        var e = player.GetComponent<RelativeObjs>().spells.ElementAtOrDefault(2);
        var f = player.GetComponent<RelativeObjs>().spells.ElementAtOrDefault(3);
        childs[0].GetComponentInChildren<LeanLocalizedText>().TranslationName = c.name;
        childs[1].GetComponentInChildren<LeanLocalizedText>().TranslationName = d.name;
        childs[2].GetComponentInChildren<LeanLocalizedText>().TranslationName = e.name;
        childs[3].GetComponentInChildren<LeanLocalizedText>().TranslationName = f.name;


    }
    public void Add()
    {
        var p = player.GetComponent<RelativeObjs>().spells[0];
        canvasManager.pickedChar.GetComponent<SpellManager>().Add(p);
        gameObject.SetActive(false);
    }
    public void Add1()
    {
        var p = player.GetComponent<RelativeObjs>().spells[1];
        canvasManager.pickedChar.GetComponent<SpellManager>().Add(p);
        gameObject.SetActive(false);
    }
    public void Add2()
    {
        var p = player.GetComponent<RelativeObjs>().spells[2];
        canvasManager.pickedChar.GetComponent<SpellManager>().Add(p);
        gameObject.SetActive(false);
    }
    public void Add3()
    {
        var p = player.GetComponent<RelativeObjs>().spells[3];
        canvasManager.pickedChar.GetComponent<SpellManager>().Add(p);
        gameObject.SetActive(false);
    }
}