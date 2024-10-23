using UnityEngine;
public abstract class AttackModificatior : MonoBehaviour
{
    [HideInInspector]
    public Base—haracteristic chars;
    [HideInInspector]
    public GameObject obj;
    public virtual void Spawn()
    {
    }
    public virtual void Damage(Base—haracteristic chars)
    {
    }
}