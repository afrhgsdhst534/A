using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Lean.Localization;
public class SpellAdd : MonoBehaviour
{
    [HideInInspector]
    public List<Spell> allSpells = new List<Spell>();
    private CanvasManager CM;
    private void OnEnable()
    {
        StartCoroutine(Next());
    }
    private void Start()
    {
        CM = CanvasManager.instance;
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(0.01f);
        allSpells = transform.parent.GetComponent<AllSpels>().allSpells;
        var b = allSpells.ElementAtOrDefault(transform.GetSiblingIndex());
        GetComponentInChildren<LeanLocalizedText>().TranslationName = b.name;
        if (allSpells.ElementAtOrDefault(transform.GetSiblingIndex()) != null)
        {
            GetComponent<Image>().sprite = allSpells[transform.GetSiblingIndex()].picture;
        }
        else
        {
            GetComponent<Image>().sprite = null;
        }
    }
    public void AddToChar()
    {
        if (CM.pickedChar != null&& allSpells.ElementAtOrDefault(transform.GetSiblingIndex()) != null)
        {
            CM.pickedChar.GetComponent<SpellManager>().Add(allSpells[transform.GetSiblingIndex()]);
            transform.parent.GetComponent<AllSpels>().allSpells.Remove(allSpells[transform.GetSiblingIndex()]);
            if (allSpells.Count <= 4)
            {
                Destroy(gameObject);
            }
            transform.parent.gameObject.SetActive(false);
        }
    }
}