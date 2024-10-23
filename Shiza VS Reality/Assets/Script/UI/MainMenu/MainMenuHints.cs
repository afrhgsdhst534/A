using UnityEngine;
public class MainMenuHints : MonoBehaviour
{
    public static MainMenuHints instance;
    private void Awake()
    {
        instance = this;
        gameObject.SetActive(false);
    }
}