using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class Puzzle : MonoBehaviour
{
    public List<Sprite> list;
    public Image[] a;
    public List<bool> b;
    public string key;
    public string imageName;
    public bool allAreTheSame;
    List<Sprite> LoadSpriteSheet(string path)
    {
        List<Sprite> spriteSheet = new List<Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        foreach (Sprite sprite in sprites)
        {
            spriteSheet.Add(sprite);
        }
        return spriteSheet;
    }
    private void Awake()
    {
        list = LoadSpriteSheet(imageName);
        a = GetComponentsInChildren<Image>();
        for (int i = 0; i < a.Length; i++)
        {
            b.Add(false);
            a[i].name = i.ToString();
            a[i].sprite = list[i];
        }
        if (PlayerPrefs.GetInt(key) == 0)
        {
            for (int i = 0; i < a.Length; i++)
            {
                var temp = a[i];
                int rand = Random.Range(i, a.Length);
                a[i] = a[rand];
                a[rand] = temp;
                a[i].transform.SetSiblingIndex(i);
            }
        }
    }
    private void Update()
    {
        if (PlayerPrefs.GetInt(key) == 0)
        {
            allAreTheSame = b.All(a => a);
            for (int i = 0; i < a.Length; i++)
            {
                if (a[i].name == System.Array.IndexOf(a, a[i]).ToString())
                {
                    b[i] = true;
                }
                else
                {
                    b[i] = false;
                }
            }
            if (allAreTheSame)
            {
                PlayerPrefs.SetInt(key, 1);
            }
        }
    }
}