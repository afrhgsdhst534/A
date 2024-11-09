using UnityEngine;
using System.Collections.Generic;
public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public bool spawn;
    public float maxTime = 10;
    public float curTime;
    public List<GameObject> enemys;
    [Header("SpawnPlanes")]
    public int x;
    public int y;
    public GameObject plane;
    Vector3 vec => plane.transform.position;
    private void OnEnable()
    {
        instance = this;
        if (x > 0 || y > 0)
            SpawnPlanes(x, y);
    }
    public void Spawn()
    {
        spawn = true;
    }
    private void Update()
    {
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        if (spawn)
        {
            curTime -= Time.deltaTime;
            if (curTime <= 0)
            {
                int ranE = Random.Range(0, enemys.Count);
                int ranN = Random.Range(1, 9);
                var c = Instantiate(enemys[ranE], RandVec(ranN), Quaternion.identity);
                c.GetComponent<BaseÑharacteristic>().isAlly = false;
                c.GetComponent<Attack>().AttackObjChanger(c.GetComponent<RelativeObjs>().attackObj);
                c.GetComponent<Rigidbody>().isKinematic = true;
                var m = c.GetComponent<MovementChanger>();
                m.movement = "ai";
                m.Next();
                curTime = maxTime;
            }
        }
    }
    public Vector3 RandVec(int ran)
    {
        switch (ran)
        {
            case 1:
                return new Vector3(-10, 0.4f, 0);
            case 2:
                return new Vector3(-10, 0.4f, 10);
            case 3:
                return new Vector3(0, 0.4f, 10);
            case 4:
                return new Vector3(10, 0.4f, 10);
            case 5:
                return new Vector3(10, 0.4f, 0);
            case 6:
                return new Vector3(10, 0.4f, -10);
            case 7:
                return new Vector3(0, 0.4f, -10);
            case 8:
                return new Vector3(-10, 0.4f, -10);
            default:
                return new Vector3(-10, 0.4f, -10);
        }
    }
    public void SpawnPlanes(int x, int y)
    {
        int j = 0;
        int t = 0;
        List<GameObject> list = new List<GameObject>();
        for (int i = 0; i < x; i++)
        {
            j++;
            if (j > x / 2)
            {
                j = 0;
            }
            if (i > x / 2) { var a = Instantiate(plane, new Vector3(vec.x + 10 * j, 0, vec.z), Quaternion.identity);list.Add(a);Destroy(a); }
            else { var a = Instantiate(plane, new Vector3(vec.x - 10 * j, 0, vec.z), Quaternion.identity); list.Add(a); Destroy(a); }
        }
        for (int i = 0; i < y; i++)
        {
            t++;
            if (t > y / 2)
            {
                t = 0;
            }
            for (int l = 0; l < list.Count; l++)
            {
                if(i>y/2)
                    Instantiate(plane, new Vector3(list[l].transform.position.x, 0, list[l].transform.position.z+10*t), Quaternion.identity);
                else
                    Instantiate(plane, new Vector3(list[l].transform.position.x, 0, list[l].transform.position.z - 10 * t), Quaternion.identity);
            }
        }
    }
}