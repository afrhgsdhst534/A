using UnityEngine;
public class ShopBuyItem : MonoBehaviour
{
    private CanvasManager canvasManager;
    [SerializeField]
    public Item item;
    private GameObject player;
    void Start()
    {
        canvasManager = CanvasManager.instance;
    }
    public void Buy()
    {
        player = canvasManager.pickedChar;
        var bc = player.GetComponent<BaseÑharacteristic>();
        if (item.cost <= bc.money&&player.GetComponent<InventoryManager>().items.Count<6)
        {
            bc.money -= item.cost;
            player.GetComponent<InventoryManager>().PickUp(item);
        }
    }
}