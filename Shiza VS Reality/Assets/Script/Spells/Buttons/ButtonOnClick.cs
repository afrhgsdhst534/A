using Lean.Localization;
using System.Collections;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class ButtonOnClick : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    private CanvasManager canvasManager;
    public bool ally;
    public Spell spell;
    [HideInInspector]
    public SpellText children;
    public GameObject plus;
    private Base—haracteristic player;
    private void Start()
    {
        canvasManager = CanvasManager.instance;
        children = GetComponentInChildren<SpellText>();
        GetComponentInChildren<LeanLocalizedText>().TranslationName = spell.name;
        plus = GetComponentInChildren<PlusScript>().gameObject;
        StartCoroutine(Next());
    }
    IEnumerator Next()
    {
        yield return new WaitForSeconds(0.05f);
        player = GetComponent<Spell>().player.GetComponent<Base—haracteristic>();
        player.onLvlUp += Show;
        if (player.lvlPoints<=0)
        {
            plus.SetActive(false);
        }
    }
    private void Update()
    {
        if (GetComponent<Spell>().LvlLimit < 1)
        {
            plus.gameObject.SetActive(false);
        }
        try
        {
            if (int.Parse(children.GetComponent<Text>().text) <= 0)
            {
                children.gameObject.SetActive(false);
            }
            else
            {
                children.gameObject.SetActive(true);
            }
        }
        catch { }
    }
    public void CheckUp()
    {
    }
    public void Button()
    {
        if (ally)
        {
            var numba = transform.GetSiblingIndex();
            var cast = canvasManager.spell.spells[numba];
            cast.Cast();
        }
        else
        {
            print("Not Ally");
        }
    }
    public void Show()
    {
        plus.gameObject.SetActive(true);
    }
    public void Plus()
    {
        if (ally)
        {
            GetComponent<Spell>().Up();
            if (player.lvlPoints<1)
            {
                plus.gameObject.SetActive(false);
            }
        }
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        try
        {
            canvasManager.hint.SetActive(true);
            canvasManager.ht.text = GetComponentInChildren<LeanLocalizedText>().gameObject.GetComponent<Text>().text;
        }
        catch { }
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        canvasManager.hint.SetActive(false);
    }
}