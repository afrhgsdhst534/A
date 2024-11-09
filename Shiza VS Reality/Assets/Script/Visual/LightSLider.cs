using UnityEngine;
using UnityEngine.UI;
public class LightSLider : MonoBehaviour
{
    LightManager manager;
    Slider slider;
    void Start()
    {
        manager = LightManager.instance;
        slider = GetComponentInChildren<Slider>();
        slider.value = PlayerPrefs.GetFloat("light");
    }
    public void Next(int i)
    {
        switch (i)
        {
            case 0:

                manager.SwapLight(false);
                PlayerPrefs.SetInt("lightS", 0);
                break;
            case 1:
                manager.SwapLight(true);
                PlayerPrefs.SetInt("lightS", 1);
                break;
        }
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("light", slider.value);
    }
    void Update()
    {
        manager.IntensivityChanger(slider.value);
    }
}