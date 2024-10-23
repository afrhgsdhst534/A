using Lean.Localization;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;
public class AddAttack : MonoBehaviour
{
    private AllAttack all;
    private CanvasManager CM;
    private void OnEnable()
    {
        all = transform.parent.GetComponent<AllAttack>();
        var c = transform.GetComponentInChildren<Text>();
        switch (all.isObj)
        {
            case true:
                if (all.allObj.ElementAtOrDefault(transform.GetSiblingIndex()) != null)
                {
                    var a = all.allObj.ElementAtOrDefault(transform.GetSiblingIndex());
                    GetComponent<Image>().sprite = a.attackObj.GetComponent<Image>().sprite;
                    c.GetComponent<LeanLocalizedText>().TranslationName = a.name;
                }
                break;
            case false:
                if (all.allMods.ElementAtOrDefault(transform.GetSiblingIndex()) != null)
                {
                    var b = all.allMods.ElementAtOrDefault(transform.GetSiblingIndex());
                    GetComponent<Image>().sprite = b.GetComponent<Image>().sprite;
                    c.GetComponent<LeanLocalizedText>().TranslationName = b.name;
                }
                break;
        }
    }
    private void Start()
    {
        CM = CanvasManager.instance;
    }
    public void AddToChar()
    {
        switch (all.isObj)
        {
            case true:
                if (CM.pickedChar != null && all.allObj.ElementAtOrDefault(transform.GetSiblingIndex()) != null)
                {
                    CM.pickedChar.GetComponent<Attack>().AttackObjChanger(all.allObj[transform.GetSiblingIndex()]);
                }
                break;
            case false:
                if (CM.pickedChar != null && all.allMods.ElementAtOrDefault(transform.GetSiblingIndex()) != null)
                {
                    CM.pickedChar.GetComponent<Attack>().AddModificator(all.allMods[transform.GetSiblingIndex()]);
                }
                break;
        }
        CM.hint.SetActive(false);
        transform.parent.gameObject.SetActive(false);
    }
}