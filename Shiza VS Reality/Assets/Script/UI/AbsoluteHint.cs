using UnityEngine;
using Lean.Localization;
using UnityEngine.UI;
using UnityEngine.EventSystems;
public class AbsoluteHint : MonoBehaviour,IPointerEnterHandler,IPointerExitHandler
{
    public GameObject hint;
    string t => GetComponentInChildren<LeanLocalizedText>().GetComponent<Text>().text;
    public void OnPointerEnter(PointerEventData eventData)
    {
        hint.GetComponent<Text>().text = t;
        hint.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hint.SetActive(false);
    }
}