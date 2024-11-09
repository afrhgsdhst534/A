using UnityEngine;
using UnityEngine.UI;
public class CameraControlerList : AList
{
    CameraController cc;
    Slider slider;
    private void Start()
    {
        cc = CameraController.instance;
        slider = GetComponentInChildren<Slider>();
        slider.value = PlayerPrefs.GetFloat("camera");
    }
    private void Update()
    {
        cc.transform.eulerAngles = new Vector3(slider.value, 0, 0);
    }
    public void Save()
    {
        PlayerPrefs.SetFloat("camera", slider.value);
    }
    public override void Use(int i)
    {
        switch (i)
        {
            case 0:
                cc.ChangeUpdate(false);
                PlayerPrefs.SetInt("cameraU", 0);
                break;
            case 1:
                cc.ChangeUpdate(true);
                PlayerPrefs.SetInt("cameraU", 1);
                break;
        }
    }
}