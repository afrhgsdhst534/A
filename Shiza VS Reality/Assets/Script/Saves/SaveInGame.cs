using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using System.Threading.Tasks;
public class SaveInGame : MonoBehaviour
{
    private CanvasManager can;
    MovementChanger move;
    public PostProcessVolume volume;
    public ColorGrading cg;
    CameraController cc;
    LightManager manager;
    private void Start()
    {
        cc = CameraController.instance;
        can = CanvasManager.instance;
        volume = Camera.main.GetComponent<PostProcessVolume>();
        volume.profile.TryGetSettings(out cg);
        cg.saturation.value = PlayerPrefs.GetFloat("saturation");
        cg.temperature.value = PlayerPrefs.GetFloat("temperature");
        cg.tint.value = PlayerPrefs.GetFloat("tint");
        cg.mixerRedOutRedIn.value = PlayerPrefs.GetFloat("mixerRedOutRedIn");
        cg.mixerRedOutGreenIn.value = PlayerPrefs.GetFloat("mixerRedOutGreenIn");
        cg.mixerRedOutBlueIn.value = PlayerPrefs.GetFloat("mixerRedOutBlueIn");
        A();
        cc.transform.eulerAngles = new Vector3(PlayerPrefs.GetFloat("camera"), 0, 0);
        cc.ChangeUpdate(System.Convert.ToBoolean(PlayerPrefs.GetInt("cameraU")));
        manager = LightManager.instance;
        manager.SwapLight(System.Convert.ToBoolean(PlayerPrefs.GetInt("lightS")));
        manager.IntensivityChanger(PlayerPrefs.GetFloat("light"));
    }
    async void A()
    {
        await Task.Delay(400);
        move = can.pickedChar.GetComponent<MovementChanger>();
        move.movement = PlayerPrefs.GetString("move");
        move.Next();
    }
}