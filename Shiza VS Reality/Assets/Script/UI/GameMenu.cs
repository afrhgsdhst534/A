using UnityEngine;
public class GameMenu : MonoBehaviour
{
    private void OnEnable()
    {
        Time.timeScale = 0;   
    }
    private void OnDisable()
    {
        Time.timeScale = 1;
    }
}