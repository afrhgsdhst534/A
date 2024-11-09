using UnityEngine;
using System.Collections.Generic;
public class Hides : MonoBehaviour
{
    public List<GameObject> objs;
    public List<GameObject> objs1;
    CanvasManager can;
    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<IAttackObject>()&&other.GetComponent<BaseÑharacteristic>().isAlly)
        {
            Hide();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<IAttackObject>() && other.GetComponent<BaseÑharacteristic>().isAlly)
        {
            Hide();
        }
    }
    public void Hide()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            objs[i].SetActive(!objs[i].activeInHierarchy);
        }
    }
    public void HideSelectedCharacter()
    {
        can = CanvasManager.instance;
        can.pickedChar.SetActive(!can.pickedChar.activeInHierarchy);
    }
    public void TrueFalse()
    {
        for (int i = 0; i < objs.Count; i++)
        {
            objs[i].SetActive(true);
        }
        for (int i = 0; i < objs1.Count; i++)
        {
            objs1[i].SetActive(false);
        }
    }
    public static void ShowObj(GameObject obj)
    {
        obj.SetActive(true);
    }
}