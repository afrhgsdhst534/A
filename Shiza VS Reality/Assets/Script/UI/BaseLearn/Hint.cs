using UnityEngine;
public class Hint : MonoBehaviour
{
    private void Update()
    {
        float a=1;
        a-=Time.deltaTime;
        if(a > 0)
        {
            a = 1;
            gameObject.SetActive(false);
        }
    }
}
