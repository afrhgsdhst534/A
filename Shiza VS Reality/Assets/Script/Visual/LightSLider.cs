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
    }
    public void Next(int i)
    {
        switch (i)
        {
            case 0:
                manager.SwapLight(false);
                break;
            case 1:
                manager.SwapLight(true);
                break;
        }
    }
    void Update()
    {
        manager.IntensivityChanger(slider.value);
    }
}
