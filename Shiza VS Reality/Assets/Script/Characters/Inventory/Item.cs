using UnityEngine;
using UnityEngine.UI;
using Lean.Localization;
using UnityEngine.EventSystems;
public abstract class Item : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerClickHandler
{
    public bool isPassive;
    public bool ally = true;
    protected CanvasManager canvasManager;
    [HideInInspector]
    public SpellText children;
    public int cost;
    public GameObject player;
    private void Start()
    {
        canvasManager = CanvasManager.instance;
        children = GetComponentInChildren<SpellText>();
        GetComponentInChildren<LeanLocalizedText>().TranslationName = GetType().Name;
    }
    public virtual void OnPick(GameObject obj)
    {
        player = obj;
    }
    public virtual void OnUse() { }
    public virtual void OnDrop()
    {
        canvasManager.CreateBarrel(this);
        gameObject.SetActive(false);
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
    public void OnPointerClick(PointerEventData ed)
    {
        if (ed.button == PointerEventData.InputButton.Right)
        {
            player.GetComponent<BaseÑharacteristic>().isAttacking = false;
            player.GetComponent<InventoryManager>().DropDown(this);
            canvasManager.hint.SetActive(false);
        }
    }
    void OnDisable()
    {
        GetComponent<Image>().raycastTarget = true;
    }
}