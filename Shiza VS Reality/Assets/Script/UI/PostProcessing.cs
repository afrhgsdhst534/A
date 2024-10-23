using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.UI;
public class PostProcessing : MonoBehaviour
{
    public Slider SE;
    public Slider[] WB;
    public Slider[] RGB;
    public PostProcessVolume volume;
    public ColorGrading cg;
    private void Start()
    {
        volume = Camera.main.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out cg);
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