using UnityEngine;
public class Box : MonoBehaviour
{
    public GameObject particles;public GameObject sound;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAttackObject>())
        {
            Instantiate(particles,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private  void OnDestroy()
    {
        GetComponent<MeshRenderer>().enabled = false;
        sound.SetActive(true);
    }
}