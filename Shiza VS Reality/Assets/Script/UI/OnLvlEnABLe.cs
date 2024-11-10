using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
public class OnLvlEnABLe : MonoBehaviour
{
    private void OnEnable()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(GetComponentsInChildren<Image>()[i].gameObject);
            }
        }
        Next();
    }
    async void Next()
    {
        await Task.Delay(10);
        Time.timeScale = 0;
    }
    private void OnDisable()
    {
        if (transform.childCount > 0)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                Destroy(GetComponentsInChildren<Image>()[i].gameObject);
            }
        }
        Time.timeScale = 1;
    }
}