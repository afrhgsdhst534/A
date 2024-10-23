using UnityEngine;
public class Signs : MonoBehaviour
{
    public GameObject obj;
    void OnTriggerStay(Collider other)
    {
        if (!other.gameObject.GetComponent<IAttackObject>())
        {
            obj.SetActive(true);
        }
        if (other.gameObject.CompareTag("Player"))
        {
            obj.SetActive(true);

        }
    }
    private void OnTriggerExit(Collider other)
    {
        obj.SetActive(false);
    }
}