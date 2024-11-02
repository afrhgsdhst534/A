using UnityEngine;using System.Threading.Tasks;
public class Projectile : IAttackObject
{
    public float force;
    private void OnEnable()
    {
        Destroy(gameObject, 0.9f + time);
        float tx = trans.position.x;
        float ty = trans.position.y;
        float tz = trans.position.z;
        float qx = trans.rotation.x;
        float qy = trans.rotation.y;
        float qz = trans.rotation.z;
        float qw = trans.rotation.w;
        transform.rotation = new Quaternion(qx, qy, qz, qw);
        transform.position = new Vector3(tx, ty, tz);
        GetComponent<Rigidbody>().AddForce(transform.forward * force, ForceMode.Impulse);
        N();
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Base—haracteristic chars))
        {

            if (bc.isAlly != chars.isAlly)
            {
                var a = this.bc.GetComponent<Attack>();
                chars.DamageCalculations(bc.attack, "physical");
                if (a.modificatior != null)
                {
                    for (int i = 0; i < a.modificatior.Count; i++)
                    {
                        a.modificatior[i].Damage(bc);
                    }
                }
                Destroy(gameObject);
            }
        }
    }
    async void N()
    {
        await Task.Delay(100);
        GetComponent<SphereCollider>().radius = 1.5f;
    }
}