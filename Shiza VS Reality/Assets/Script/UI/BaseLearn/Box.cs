using UnityEngine;
public class Box : MonoBehaviour
{
    public GameObject particles;public GameObject sound;private AllyCharacters ally;
    private void OnTriggerEnter(Collider other)
    {
        if (other.GetComponent<IAttackObject>())
        {
            ally = AllyCharacters.instance;
            Instantiate(particles,transform.position,Quaternion.identity);
            Destroy(gameObject);
        }
    }
    private  void OnDestroy()
    {
        ally.allAllyCharacters[0].GetComponent<BaseÑharacteristic>().curLvl += 100;
        GetComponent<MeshRenderer>().enabled = false;
        sound.SetActive(true);
    }
}
