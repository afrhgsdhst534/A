using UnityEngine;
using System.Collections;
using UnityEngine.UI;
public class HPSlider : MonoBehaviour
{
    Transform cam;
    Slider slider;
    GameObject parent;
    Base—haracteristic bc;
    private void Start()
    {
        cam = Camera.main.transform;
        var a = transform.parent;
        parent = a.parent.gameObject;
        slider = GetComponent<Slider>();
        bc = parent.GetComponent<Base—haracteristic>();
        StartCoroutine(Tick());
    }
    IEnumerator Tick()
    {
        yield return new WaitForSeconds(0.4f);
        slider.maxValue = bc.maxHp;
        slider.value = bc.curHp;
        StartCoroutine(Tick());
    }
    private void LateUpdate()
    {
        if(cam!=null)
        transform.rotation = cam.rotation;
    }
}