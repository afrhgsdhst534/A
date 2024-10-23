using UnityEngine;
public class KAMEHb : MonoBehaviour
{
    public GameObject player;
    private void Start()
    {
        player = transform.parent.gameObject;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.layer == LayerMask.NameToLayer("Attack") && enabled)
        {
            var obj = other.GetComponent<IAttackObject>().bc;
            var p = player.GetComponent<Base�haracteristic>();
            if (!obj.isAlly)
            {
                obj.DamageCalculations(p.armour+p.magicResist, "magical");
            }
        }
    }
}