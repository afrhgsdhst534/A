using UnityEngine;
using System.Collections.Generic;
public abstract class AList : MonoBehaviour
{
    protected bool isRand;
    public List<GameObject> list;
    public int buttons;
    protected virtual void OnEnable()
    {
        if (isRand)
            for (int i = 0; i < list.Count; i++)
            {
                var temp = list[i];
                int rand = Random.Range(i, list.Count);
                list[i] = list[rand];
                list[rand] = temp;
                Instantiate(list[i], transform);
            }
    }
    private void OnDisable()
    {
        if (isRand)

            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(transform.GetChild(0).gameObject);
            }
    }
    public virtual void Use(int i)
    {
    }
}