using UnityEngine;
public class HitThemAll : IAttackObject
{
    GameObject obj;
    private void OnEnable()
    {
        Destroy(gameObject, 0.9f+time);
        float tx = trans.position.x;
        float ty = trans.position.y + 1;
        float tz = trans.position.z;
        float qx = trans.rotation.x;
        float qy = trans.rotation.y;
        float qz = trans.rotation.z;
        float qw = trans.rotation.w;
        transform.position = new Vector3(tx, ty, tz);
        transform.rotation = new Quaternion(qx, qy, qz, qw);
        transform.Rotate(0, -180, 0);
        transform.SetParent(bc.transform);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Base—haracteristic chars))
        {
            obj = other.gameObject;
            if (!bc.targets.Contains(obj))
            {
                bc.targets.Add(obj);
            }
            Trigger(chars);
        }
    }
    void OnDestroy()
    {
        if(bc.targets.Contains(obj))
            bc.targets.Remove(obj);
        for (int i = 0; i < bc.targets.Count; i++)
        {
            bc.targets.RemoveAt(i);
        }
    }
    void Trigger(Base—haracteristic bc)
    {
        bc.DamageCalculations(this.bc.attack, "true");
        var a = this.bc.GetComponent<Attack>();
        if (a.modificatior != null)
        {
            for(int i = 0;i<a.modificatior.Count;i++)
            {
                a.modificatior[i].Damage(bc);
            }
        }
    }
}