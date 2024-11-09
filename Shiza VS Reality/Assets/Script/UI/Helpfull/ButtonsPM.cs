using UnityEngine;
using System.Collections.Generic;
public class ButtonsPM : MonoBehaviour
{
    public static ButtonsPM instance;
    public GameObject allSpellList;
    public GameObject AllAttackMods;
    public GameObject AllAttackObj;
    public GameObject Shop;
    public GameObject shopButtons;
    private CanvasManager canvasManager;
    private Base—haracteristic player;
    private InventoryManager inventory;
    public GameObject[] bans;
    public List<Item> items;
    void Awake()
    {
        instance = this;
    }
    private void Start()
    {
        canvasManager = CanvasManager.instance;
    }
    public void Update()
    {
        for (int i = 0; i < bans.Length; i++)
        {
            bans[i].SetActive(false);
        }
    }
    public void RefreshItems()
    {
        player = canvasManager.pickedChar.GetComponent<Base—haracteristic>();
        inventory = canvasManager.pickedChar.GetComponent<InventoryManager>();
        int value = 0;
        for (int i = 0; i < inventory.items.Count; i++)
        {
            value += inventory.items[i].cost / 2;
        }
        if (player.money >= value)
        {
            inventory.RefreshItems();
            player.money -= value;
        }
    }
    public void GemOnUse()
    {
        player = canvasManager.pickedChar.GetComponent<Base—haracteristic>();
        inventory = canvasManager.pickedChar.GetComponent<InventoryManager>();
        if (player.money >= 500)
        {
            player.money -= 500;
            Vector3 vector3 = new Vector3(player.transform.position.x + 1, player.transform.position.y, player.transform.position.z + 1);
            var obj = Instantiate(player, vector3, Quaternion.identity);
            obj.GetComponent<MovementChanger>().movement = "mouse";
            obj.GetComponent<MovementChanger>().Next();
        }
    }
}