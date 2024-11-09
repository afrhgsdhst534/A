using UnityEngine;
public class ShopHides : MonoBehaviour
{
    ButtonsPM pm;
    GameObject shop;
    GameObject shopBut;
    private void Awake()
    {
        pm = ButtonsPM.instance;
    }
    void Start()
    {
        shop = pm.Shop;
        shopBut = pm.shopButtons;
    }
    public void Hides()
    {
        shop.SetActive(!shop.activeInHierarchy);
        shopBut.SetActive(!shopBut.activeInHierarchy);
    }
}