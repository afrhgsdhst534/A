using System.Collections.Generic;
using UnityEngine;
public class InventoryManager : MonoBehaviour
{
    public List<Item> items;
    public GameObject inventory;
    public GameObject obj;
    public void PickUp(Item item)
    {
        obj = Instantiate(item.gameObject);
        obj.gameObject.SetActive(true);
        items.Add(obj.GetComponent<Item>());
        obj.transform.SetParent(inventory.transform);
        obj.transform.SetSiblingIndex(items.Count - 1);
        obj.GetComponent<Item>().ally = GetComponent<BaseÑharacteristic>().isAlly;
        obj.GetComponent<Item>().OnPick(gameObject);
        obj.transform.localScale = Vector3.one;
        obj.transform.position = Vector3.zero;
    }
    private void Update()
    {
        if (obj != null)
            if (obj != null && obj.transform.rotation != Quaternion.Euler(0, 0, 0))
            {
                obj.transform.rotation = Quaternion.Euler(0, 0, 0);
            }
    }
    public void DropDown(Item item)
    {
        if (item.ally)
            items.Remove(item);
        item.OnDrop();
    }
    public void Sell(Item item)
    {
        var value = item.cost;
        GetComponent<BaseÑharacteristic>().money += item.cost / 2;
        items.Remove(item);
        Destroy(item.gameObject);
    }
    public void RefreshItems()
    {
        for (int i = 0; i < items.Count; i++)
        {
            Destroy(items[i].gameObject);
        }
        items.Clear();
    }
}