using UnityEngine;
public class ForTheFirstTimeSet : MonoBehaviour
{
    int i;
    void Start()
    {
        i = PlayerPrefs.GetInt("ForTheFirstTimeSet");
        if (i == 0)
        {
            PlayerPrefs.SetString("ATTACK", "Space");
            PlayerPrefs.SetString("ONE", "Alpha1");
            PlayerPrefs.SetString("TWO", "Alpha2");
            PlayerPrefs.SetString("THREE", "Alpha3");
            PlayerPrefs.SetString("FOUR", "Alpha4");
            PlayerPrefs.SetString("FIVE", "Alpha5");
            PlayerPrefs.SetString("SIX", "Alpha6");
            PlayerPrefs.SetString("Z", "Z");
            PlayerPrefs.SetString("X", "X");
            PlayerPrefs.SetString("C", "C");
            PlayerPrefs.SetString("V", "V");
            PlayerPrefs.SetString("W", "W");
            PlayerPrefs.SetString("A", "A");
            PlayerPrefs.SetString("S", "S");
            PlayerPrefs.SetString("D", "D");
            PlayerPrefs.SetFloat("VOLUME", 0.5f);
            PlayerPrefs.SetFloat("saturation", 90);
            PlayerPrefs.SetFloat("temperature", 70);
            PlayerPrefs.SetFloat("mixerRedOutRedIn", 111);
            PlayerPrefs.SetInt("lightS", 1);
            PlayerPrefs.SetInt("cameraU", 1);
            PlayerPrefs.SetFloat("light", 1.15f);
            PlayerPrefs.SetString("move", "arrow");
        }
         PlayerPrefs.SetInt("ForTheFirstTimeSet", 1);
    }
}