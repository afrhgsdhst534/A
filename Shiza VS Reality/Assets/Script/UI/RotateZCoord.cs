using UnityEngine;
using UnityEngine.EventSystems;
public class RotateZCoord : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    bool activate;
    void Update()
    {
        if(activate)
            transform.Rotate(0, 0, 2);
    }
    public void OnPointerEnter(PointerEventData eventData)
    {
        activate = true;
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        activate = false;
    }
}