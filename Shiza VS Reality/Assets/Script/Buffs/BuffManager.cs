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
        var b = Instantiate(buff);
        buffs.Add(b);
        b.OnAwake(gameObject);
        b.player = gameObject;
        b.transform.SetParent(buffsObj.transform);
        b.GetComponent<Image>().sprite = buff.GetComponent<Image>().sprite;
        StartCoroutine(Next(b.gameObject));
    }
    public void BuffRemove(Buff buff)
    {
        var b = buff.GetType().Name;
        buff.OnRemove();
        for (int i = 0; i < buffs.Count; i++)
        {
            if(buffs[i].GetType().Name == b)
            {
                Destroy(buffs[i].gameObject);
                buffs.RemoveAt(i);
            }
        }
    }
    IEnumerator Next(GameObject buff)
    {
        yield return new WaitForSeconds(0.4f);
        try
        {
            buff.GetComponent<RectTransform>().localScale = Vector3.one;
            buff.transform.eulerAngles.Set(0,0,0);
            buff.transform.position = new Vector3(buff.transform.position.x, buff.transform.position.y,0);
        }
        catch { }
    }
    public bool IFThereBuff(string name)
    {
        bool b = false;
        for (int i = 0; i < buffs.Count; i++)
        {
            if (name== buffs[i].GetType().Name)
            {
                b = true;
            }
            else { b = false; }
        }
        return b;
    }
    public Buff BuffByName(string a)
    {
        Buff b = null;
        for (int i = 0; i < buffs.Count; i++)
        {
            if (buffs[i].GetType().Name == a)
            {
                b = buffs[i];
            }
        }
        return b;
    }

}