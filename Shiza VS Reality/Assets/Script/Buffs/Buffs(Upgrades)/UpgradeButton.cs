using System.Collections.Generic;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
using Lean.Localization;
public class UpgradeButton : MonoBehaviour
{
    private CanvasManager manager;
    private List<Upgrade> upgrades;
    private void Start()
    {
        manager = CanvasManager.instance;
    }
    private void OnEnable()
    {
        StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(0.01f);
         upgrades = transform.parent.GetComponent<AllUpgrades>().upgrades;
        var b = upgrades.ElementAtOrDefault(transform.GetSiblingIndex());
        GetComponentInChildren<LeanLocalizedText>().TranslationName = b.name;
        if (upgrades.ElementAtOrDefault(transform.GetSiblingIndex()) != null)
        {
            GetComponent<Image>().sprite = upgrades[transform.GetSiblingIndex()].GetComponent<Image>().sprite;
        }
        else
        {
            GetComponent<Image>().sprite = null;
        }
    }
    public void Upgrade()
    {
        upgrades[transform.GetSiblingIndex()].OnUpgrade(manager.pickedChar);
        transform.parent.gameObject.SetActive(false);
    }
}