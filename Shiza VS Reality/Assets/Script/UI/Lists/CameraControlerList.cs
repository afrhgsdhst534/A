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
    }
    private void Update()
    {
        cc.cinema.transform.eulerAngles = new Vector3(slider.value, 0, 0);
    }
    public override void Use(int i)
    {
        switch (i)
        {
            case 0:
                cc.ChangeUpdate(false);
                break;
            case 1:
                cc.ChangeUpdate(true);
                break;
        }
    }
}