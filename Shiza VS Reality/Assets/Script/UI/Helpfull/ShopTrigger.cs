using UnityEngine;
public class ShopTrigger : MonoBehaviour
{
    private ButtonsPM pm;
    private void Start()
    {
        pm = ButtonsPM.instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out RelativeObjs objs))
        {
            objs.shop.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.TryGetComponent(out RelativeObjs objs))
            objs.shop.SetActive(false);
            pm.Shop.SetActive(false);
            pm.shopButtons.SetActive(false);
    }
}