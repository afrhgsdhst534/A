using UnityEngine;
using UnityEngine.UI;
public abstract class Buff : MonoBehaviour
{
    public GameObject player;
    public int value;
    public Text text;
    public virtual void OnAwake(GameObject obj)
    {
        text = GetComponentInChildren<Text>();
        text.gameObject.SetActive(false);
    }
    public virtual void OnRemove() { }
    public virtual void PlusValue(int value){this.value+=value;text.text=this.value.ToString();text.gameObject.SetActive(true);}
    public virtual void Create(int value)
    {
    }
    public virtual void Clear(int level)
    {
    }
}