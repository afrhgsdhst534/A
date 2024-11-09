using UnityEngine;
using UnityEngine.UI;
public class PuzzleActivator : MonoBehaviour
{
    public GameObject obj;
    public string key;
    void Start()
    {
        Image i = GetComponent<Image>();
        if (PlayerPrefs.GetInt(key) == 1)
        {
            i.color = new Color(255, 255, 0);
        }
        if (PlayerPrefs.GetInt(obj.GetComponent<Puzzle>().key)==1)
        {
            i.color = new Color(0, 255, 0);
        }
    }
    public void Open()
    {
        if (PlayerPrefs.GetInt(key) ==1)
        {
            obj.SetActive(true);
            transform.parent.gameObject.SetActive(false);
        }
    }
    public void Scn()
    {
        UnityEngine.SceneManagement.SceneManager.LoadScene(0);
    }
}