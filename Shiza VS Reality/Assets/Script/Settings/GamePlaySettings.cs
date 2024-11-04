using UnityEngine;using System;
public class GamePlaySettings : MonoBehaviour
{
    public bool arrowIsFollowMouse;
    public static GamePlaySettings instance;
    public void Awake()
    {
        instance = this;
        arrowIsFollowMouse = Convert.ToBoolean(PlayerPrefs.GetInt("AIFM"));
    }
}