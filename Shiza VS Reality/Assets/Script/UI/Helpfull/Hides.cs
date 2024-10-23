using UnityEngine;
public class Hides : MonoBehaviour
{
    public GameObject[] objs;
    public GameObject[] objs1;
    CanvasManager can;
    void OnTriggerExit(Collider other)
    {
        if (!other.gameObject.GetComponent<IAttackObject>()&&other.GetComponent<Base�haracteristic>().isAlly)
        {
            Hide();
        }
    }
    void OnTriggerEnter(Collider other)
    {
        if (!other.gameObject.GetComponent<IAttackObject>() && other.GetComponent<Base�haracteristic>().isAlly)
        {
            Hide();
        }
    }
    public void Hide()
    {
        for (int i = 0; i < objs.Length; i++)
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
        for (int i = 0; i < objs.Length; i++)
        {
            objs[i].SetActive(true);
        }
        for (int i = 0; i < objs1.Length; i++)
        {
            objs1[i].SetActive(false);
        }
    }
    public static void ShowObj(GameObject obj)
    {
        obj.SetActive(true);
    }
}