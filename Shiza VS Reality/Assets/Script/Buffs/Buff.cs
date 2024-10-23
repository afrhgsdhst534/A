using UnityEngine;
public abstract class Buff : MonoBehaviour
{
    public GameObject player;
    public virtual void OnAwake(GameObject obj) { }
    public virtual void OnRemove() { }
    public virtual void Create(int value)
    {
    }
    public virtual void Clear(int level)
    {
    }
}