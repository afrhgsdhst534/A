using System.Collections.Generic;
using UnityEngine;
public class SpriteTest : MonoBehaviour
{
    public List<Sprite> list;
    List<Sprite> LoadSpriteSheet(string path)
    {
        List <Sprite> spriteSheet = new List< Sprite>();
        Sprite[] sprites = Resources.LoadAll<Sprite>(path);
        foreach (Sprite sprite in sprites)
        {
            spriteSheet.Add(sprite);
        }
        return spriteSheet;
    }

    private void Start()
    {
        list = LoadSpriteSheet("Test");
    }
}