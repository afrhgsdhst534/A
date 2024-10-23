using UnityEngine;
public class LightManager : MonoBehaviour
{
    public static LightManager instance;
    public Transform defaultLight;
    public Transform shadowLight;
    private void Awake()
    {
        instance = this;
        defaultLight= transform.GetChild(0);
        shadowLight = transform.GetChild(1);
    }
    public void SwapLight(bool isDefault)
    {
        if (isDefault)
        {
            defaultLight.gameObject.SetActive(true);
            shadowLight.gameObject.SetActive(false);
        }
        else
        {
            defaultLight.gameObject.SetActive(false);
            shadowLight.gameObject.SetActive(true);
        }
    }
    public void IntensivityChanger(float f)
    {
        defaultLight.GetComponent<Light>().intensity = f;
        shadowLight.GetComponent<Light>().intensity = f;
    }
}