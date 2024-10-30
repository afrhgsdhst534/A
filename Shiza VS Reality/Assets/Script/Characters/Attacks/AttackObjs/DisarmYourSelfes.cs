using UnityEngine;
public class DisarmYourSelfes : IAttackObject
{
    GameObject obj;
    public float delay;
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
        transform.Translate(1, 2, 4);
        transform.Rotate(0, -90, 0);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Base—haracteristic chars))
        {
            if (bc.isAlly)
            {

                if (!chars.isAlly)
                {
                    obj = other.gameObject;
                    chars.GetComponent<Attack>().delay += 0.5f;
                    if (!bc.targets.Contains(obj))
                    {
                        bc.targets.Add(obj);
                    }
                    Trigger(chars);
                }
            }
            else
            {
                if (chars.isAlly)
                {
                    obj = other.gameObject;
                    chars.GetComponent<Attack>().delay += 0.5f;
                    if (!bc.targets.Contains(obj))
                    {
                        bc.targets.Add(obj);
                    }
                    Trigger(chars);
                }
            }
        }
    }
    void OnDestroy()
    {
        if (bc.targets.Contains(obj))
            bc.targets.Remove(obj);
        for (int i = 0; i < bc.targets.Count; i++)
        {
            bc.targets.RemoveAt(i);
        }
    }
    void Trigger(Base—haracteristic bc)
    {
        bc.DamageCalculations(this.bc.attack, "magical");
        var a = this.bc.GetComponent<Attack>();
        if (a.modificatior != null)
        {
            for (int i = 0; i < a.modificatior.Count; i++)
            {
                a.modificatior[i].Damage(bc);
            }
        }
    }
}