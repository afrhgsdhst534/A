using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using Lean.Localization;
public class Hints : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    CanvasManager canvasManager;
    void Start()
    {
        canvasManager = CanvasManager.instance;
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        canvasManager.hint.SetActive(true);
        var a = GetComponentInChildren<LeanLocalizedText>();
        canvasManager.ht.text = a.GetComponent<Text>().text;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        canvasManager.hint.SetActive(false);
    }
    public void OnDisable()
    {
        try { canvasManager.hint.SetActive(false); }
        catch { }
    }
}