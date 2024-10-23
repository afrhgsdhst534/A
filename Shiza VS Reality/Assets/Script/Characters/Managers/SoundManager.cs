using UnityEngine;
public class SoundManager : MonoBehaviour
{
    public float volume;
    private void Update()
    {
        AudioListener.volume = volume;
    }
}