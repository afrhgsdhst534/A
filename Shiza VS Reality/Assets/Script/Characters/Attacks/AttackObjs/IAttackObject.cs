using UnityEngine;
public abstract class IAttackObject:MonoBehaviour
{
    [HideInInspector]
    public Base—haracteristic bc;
    [HideInInspector]
    public Transform trans;
    [HideInInspector]
    public bool isAlly;
    public UIAttackObj attackObj;
    public float time;
    [HideInInspector]
    public float curTime;
}