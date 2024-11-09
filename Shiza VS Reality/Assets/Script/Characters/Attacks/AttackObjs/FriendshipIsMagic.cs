using UnityEngine;
using System.Collections;
public class FriendshipIsMagic : IAttackObject
{
    private void OnEnable()
    {
        Destroy(gameObject, 0.9f + time);
        float tx = trans.position.x;
        float ty = trans.position.y;
        float tz = trans.position.z;
        transform.position = new Vector3(tx, ty, tz);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.TryGetComponent(out Base—haracteristic chars))
        {
            if (chars.isAlly!=bc.isAlly)
            {
                var a = this.bc.GetComponent<Attack>();
                if (a.modificatior != null)
                {
                    for (int i = 0; i < a.modificatior.Count; i++)
                    {
                        a.modificatior[i].Damage(chars);
                    }
                }
            }
            else
            {
                StartCoroutine(Next(chars));
            }
        }
    }
    IEnumerator Next(Base—haracteristic bc)
    {
        for (float i = 0; i < 0.9f; i+=0.1f)
        {
            yield return new WaitForSeconds(0.1f);
            bc.DamageCalculations(-this.bc.attack/9,"true");
        }
    }
}