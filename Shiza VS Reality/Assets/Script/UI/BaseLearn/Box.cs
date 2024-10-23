using UnityEngine;
public class Box : MonoBehaviour
{
    public GameObject particles;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAttackObject>())
        {
            Instantiate(particles,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
}