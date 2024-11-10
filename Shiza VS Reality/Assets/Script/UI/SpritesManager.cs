using UnityEngine;
public class SpritesManager : MonoBehaviour
{
    public Texture2D defaultCursor;
    public Texture2D badCursor;
    public Texture2D goodCursor;
    public static SpritesManager instance;
    private void Awake()
    {
        instance = this;
    }
    void Start()
    {
        ChangeCursor(defaultCursor);
    }
    public void ChangeCursor(Texture2D texture)
    {
        Cursor.SetCursor(texture, Vector2.zero, CursorMode.Auto);
    }
    private void OnEnable()
    {
        ChangeCursor(defaultCursor);
    }
    private void OnDestroy()
    {
        ChangeCursor(defaultCursor);
    }
}