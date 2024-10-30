using System.Collections;
using UnityEngine;
public class HighGround : MonoBehaviour
{
    public Buff buff;
    private void OnTriggerEnter(Collider other)
    {
        if(other.TryGetComponent(out BuffManager manager))
        {
            manager.BuffAdd(buff);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.TryGetComponent(out BuffManager manager))
        {
            manager.BuffRemove(buff);
        }
    }
}