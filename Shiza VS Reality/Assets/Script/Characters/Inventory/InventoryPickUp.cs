using UnityEngine;
public class InventoryPickUp : MonoBehaviour
{
    public Item item;
    [HideInInspector]
    public CanvasManager a;
    private void Start()
    {
        a = CanvasManager.instance;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out InventoryManager manager))
        {
            Next(manager);
        }
        if (other.gameObject.GetComponent<IAttackObject>())
        {
            Destroy(gameObject);
        }
    }
    private void OnMouseDown()
    {
        Next(a.pickedChar.GetComponent<InventoryManager>());
    }
    public void Next(InventoryManager manager)
    {
        if(manager.items.Count < 6)
        {
            manager.PickUp(item);
            Destroy(gameObject);
        }
    }
}