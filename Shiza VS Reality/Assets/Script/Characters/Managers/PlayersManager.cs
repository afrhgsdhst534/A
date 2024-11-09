using System.Collections.Generic;
using UnityEngine;
public class PlayersManager : MonoBehaviour
{
    public List<Base—haracteristic> bc;
    public GameObject obj;
    public GameObject hint;
    public void Next(Base—haracteristic bc)
    {
        var c = Instantiate(bc, new Vector3(0, 0, 0), Quaternion.identity);
        c.GetComponent<Attack>().AttackObjChanger(c.GetComponent<RelativeObjs>().attackObj);
        c.isAlly = true;
        obj.SetActive(true);
        Destroy(transform.parent.gameObject);
    }
}