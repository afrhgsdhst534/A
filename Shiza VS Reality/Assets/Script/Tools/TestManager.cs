using UnityEngine;
public class TestManager : MonoBehaviour
{
    private TestManager instance;
    private AllyCharacters character;
    private void Start()
    {
        instance = this;
        character = AllyCharacters.instance;
    }
    [ContextMenu("ThrowUp")]
    public void ThrowUp()
    {
        var player = character.allAllyCharacters[0];
        player.GetComponent<Rigidbody>().velocity = transform.up * 10;
    }
}