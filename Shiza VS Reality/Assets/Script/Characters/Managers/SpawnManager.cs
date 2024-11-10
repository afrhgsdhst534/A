using UnityEngine;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;
    public bool spawn;
    public float maxTime = 5;
    public float curTime;
    public List<GameObject> enemys;
    [Header("SpawnPlanes")]
    public int x;
    public int y;
    public GameObject plane;
    int lvl;
    int spd;
    Vector3 vec => plane.transform.position;
    public Transform spawner;
    CanvasManager can;
    public List<AudioSource> AS;
    public GameObject onEnd;
    private void OnEnable()
    {
        Time.timeScale = 1;
        instance = this;
        if (x > 0 || y > 0)
            SpawnPlanes(x, y);
    }
    public void Restart()
    {
        SceneManager.LoadScene(1);
    }
    public void Spawn()
    {
        var r = Random.Range(0, AS.Count);
        AS[r].Play();
        can = CanvasManager.instance;
        var s = Instantiate(spawner.gameObject,can.pickedChar.transform);
        s.transform.Translate(0, 0, 7.5f);
        spawner = s.transform;
        spawn = true;
    }
    private void Update()
    {
        if (spawner == null)
        {
            onEnd.SetActive(true);
            Time.timeScale = 0;
        }
        SpawnEnemy();
    }
    public void SpawnEnemy()
    {
        if (spawn)
        {
            curTime -= Time.deltaTime;
            if (curTime <= 0)
            {
                var r = Random.Range(0, enemys.Count);
                var c=  Instantiate(enemys[r], spawner.position, Quaternion.identity);
                var b = c.GetComponent<BaseÑharacteristic>();
                b.isAlly = false;
                b.curLvl+=lvl;
                b.speed += spd;
                spd += 10;
                lvl += 100;
                c.GetComponent<Attack>().AttackObjChanger(c.GetComponent<RelativeObjs>().attackObj);
                c.GetComponent<Rigidbody>().isKinematic = true;
                var m = c.GetComponent<MovementChanger>();
                m.movement = "ai";
                m.Next();
                curTime = maxTime;
            }
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