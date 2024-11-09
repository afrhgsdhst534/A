using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class PostProcessing : MonoBehaviour
{
    public PostProcessing a;
    public Slider SE;
    public Slider[] WB;
    public Slider[] RGB;
    public PostProcessVolume volume;
    public ColorGrading cg;
    private void Start()
    {
        volume = Camera.main.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out cg);
        SE.value = PlayerPrefs.GetFloat("saturation");
        WB[0].value = PlayerPrefs.GetFloat("temperature");
        WB[1].value = PlayerPrefs.GetFloat("tint");
        RGB[0].value = PlayerPrefs.GetFloat("mixerRedOutRedIn");
        RGB[1].value = PlayerPrefs.GetFloat("mixerRedOutGreenIn");
        RGB[2].value = PlayerPrefs.GetFloat("mixerRedOutBlueIn");
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("saturation", SE.value);
        PlayerPrefs.SetFloat("temperature", WB[0].value);
        PlayerPrefs.SetFloat("tint", WB[1].value);
        PlayerPrefs.SetFloat("mixerRedOutRedIn", RGB[0].value);
        PlayerPrefs.SetFloat("mixerRedOutGreenIn", RGB[1].value);
        PlayerPrefs.SetFloat("mixerRedOutBlueIn", RGB[2].value);
    }
    private void Update()
    {
        try
        {
            cg.saturation.value = SE.value;
            cg.temperature.value = WB[0].value;
            cg.tint.value = WB[1].value;
            cg.mixerRedOutRedIn.value = RGB[0].value;
            cg.mixerRedOutGreenIn.value = RGB[1].value;
            cg.mixerRedOutBlueIn.value = RGB[2].value;
        }
        catch { }
    }
}