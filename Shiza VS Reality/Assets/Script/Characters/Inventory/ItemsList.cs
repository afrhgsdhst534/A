using UnityEngine;
using System.Collections.Generic;
public class ItemsList : MonoBehaviour
{
    public List<Item> items;
    public static ItemsList instance;
    private void Awake()
    {
        instance = this;
    }
    public Item ItemFinder(Item item)
    {
        Item itm = null;
        for (int i = 0; i < items.Count; i++)
        {
            if (item.GetType().Name == items[i].GetType().Name)
            {
                itm = items[i];
            }
        }
        return itm;
    }
}