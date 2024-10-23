using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
public class MainMenuEnableHint : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public MainMenuHints hint;
    private Text text;
    void Start()
    {
        hint = MainMenuHints.instance;
        text = hint.GetComponentInChildren<Text>();
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        hint.gameObject.SetActive(true);
        var a = GetComponent<MainMenuEnableHint>();
        text.text = a.GetComponentInChildren<Text>().text;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        hint.gameObject.SetActive(false);
    }
}
