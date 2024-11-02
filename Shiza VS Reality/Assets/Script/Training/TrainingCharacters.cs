using UnityEngine;
public class TrainingCharacters : MonoBehaviour
{
    Training tr;
    private void Start()
    {
        tr = Training.a;
        gameObject.GetComponent<MeshRenderer>().material = tr.mat;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.layer==LayerMask.NameToLayer("Ground"))
        {
            var a = Instantiate(tr.chars[0], gameObject.transform.position, Quaternion.identity);
            a.GetComponent<BaseÑharacteristic>().curLvl += tr.lvl;
            a.GetComponent<Attack>().AttackObjChanger(tr.atObj);
            Destroy(gameObject);
        }
    }
}