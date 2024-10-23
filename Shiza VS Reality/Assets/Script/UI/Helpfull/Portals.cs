using UnityEngine;
using UnityEngine.UI;
using System;
public class Portals : MonoBehaviour
{
   public float timer  = 0;
    public Transform tr;
    public Slider s;
    public Action onTeleport;
    private void Start()
    {
        s.maxValue = 4;
    }
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            s.gameObject.SetActive(true);
            timer += Time.deltaTime;
            s.value = timer;
            if (timer >= 4)
            {
                other.transform.position = tr.position;
                onTeleport?.Invoke();
            }
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            s.gameObject.SetActive(false);
            timer = 0;
        }

    }
}