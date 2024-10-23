using UnityEngine;
public class GamePlaySettings : MonoBehaviour
{
    public bool arrowIsFollowMouse;
    public static GamePlaySettings instance;
    public void Awake()
    {
        instance = this;
    }
}