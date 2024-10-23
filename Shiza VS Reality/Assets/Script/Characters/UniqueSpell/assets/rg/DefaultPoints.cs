using UnityEngine;
public class DefaultPoints : MonoBehaviour
{
    public RacoonBodyObj obj;
    private void Start()
    {
        obj.pointsEnd++;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            obj.points++;
            Destroy(gameObject);
        }
    }
}