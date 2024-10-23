using UnityEngine;
using System.Collections.Generic;
using UnityEngine.UI;
public abstract class Building : MonoBehaviour
{
    public int hp;
    private Transform canvas;
    public GameObject onDestroyObj;
    private GridLayoutGroup t;
    private Transform cam;
    public GameObject hpObj;
    public List<GameObject> hpObjs;
    Vector3 vec;
    private void Start()
    {
        canvas = GetComponentInChildren<Transform>();
        t = canvas.GetComponentInChildren<GridLayoutGroup>();
         vec = new Vector3(0,0, -2.17f);
        cam = Camera.main.transform;
        AddHp(hp);
    }
    public void AddHp(int hp)
    {
        for(int i = 0; i < hp; i++)
        {
            var a = Instantiate(hpObj);
            hpObjs.Add(a);
            hpObjs[i].transform.SetParent(t.transform);
            hpObjs[i].SetActive(true);
            hpObjs[i].transform.position = vec;
            hpObjs[i].transform.eulerAngles = new Vector3(53, 0, 0);
        }
    }
    private void LateUpdate()
    {
        if(cam!=null)
            t.transform.rotation = cam.rotation;
    }
    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.GetComponent<IAttackObject>())
        {
            hp--;
            Destroy(hpObjs[0]);
            hpObjs.Remove(hpObjs[0]);
            if (hp < 1)
            {
                Instantiate(onDestroyObj, transform);
                Destroy(gameObject);
            }
        }
    }
}