using UnityEngine;
public class FPSChanger : MonoBehaviour
{
    public int fps;
    public static FPSChanger instance;
    private void OnEnable()
    {
        instance = this;
    }
    void Update()
    {
        Application.targetFrameRate = fps;
    }
}