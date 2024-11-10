using UnityEngine;
public class TaimingSet : MonoBehaviour
{
    public float timer;
    public string key;
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= 180)
        {
            PlayerPrefs.SetInt(key, 1);
        }
        if (timer >= 240)
        {
            PlayerPrefs.SetInt("invite9", 1);
        }
    }
}