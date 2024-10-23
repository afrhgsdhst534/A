using UnityEngine;
public abstract class UniqueSpell : MonoBehaviour
{
    public int value;
    public GameObject obj;
    protected AllyCharacters ally;
    protected EnemyCharacters enemy;
    protected CanvasManager canvas;
    protected CameraController cam;
    protected bool active;
    private void Start()
    {
        ally = AllyCharacters.instance;
        enemy = EnemyCharacters.instance;
        canvas = CanvasManager.instance;
        cam = CameraController.instance;
    }
    public virtual void Cast()
    {
    }
    public virtual void GameOver()
    {
    }
    public virtual void Win()
    {
    }
}