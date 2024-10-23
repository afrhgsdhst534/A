using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class BuffManager : MonoBehaviour
{
    public GameObject buffsObj;
    public List<Buff> buffs;
    public void BuffAdd(Buff buff)
    {
        buffs.Add(buff);
        buff.OnAwake(gameObject);
        var b = Instantiate(buff);
        b.transform.SetParent(buffsObj.transform);
        buff.GetComponent<Image>().sprite = buff.GetComponent<Image>().sprite;
        StartCoroutine(Next(b.gameObject));
    }
    IEnumerator Next(GameObject buff)
    {
        yield return new WaitForSeconds(0.01f);
        try
        {
            buff.transform.localScale = Vector3.one;
        }
        catch { }
    }
    public void BuffRemove(Buff buff)
    {
        buff.OnRemove();
        for (int i = 0; i < buffsObj.GetComponentsInChildren<Buff>().Length; ++i)
        {
            if (buffs[i] == buff)
            {
                Destroy(buffsObj.GetComponentsInChildren<Buff>()[i].gameObject);
                buffs.Remove(buff);
            }
        }
    }
}