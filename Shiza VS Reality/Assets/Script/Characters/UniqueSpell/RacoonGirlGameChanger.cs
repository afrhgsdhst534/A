using UnityEngine;
using System.Collections.Generic;
using MyTools;
using Cinemachine;
public class RacoonGirlGameChanger : UniqueSpell
{
    public GameObject enemys;
    public GameObject player;
    private List<GameObject> e=>enemy.allEnemyCharacters;
    private List<GameObject> al=>ally.allAllyCharacters;
    public List<GameObject> garbageCollector;
    private GameObject o;
    private GameObject rgo;
    public List<Material> mat;
    public GameObject points;
    private LightManager lait;
    public override void Cast()
    {
        if (e.Count > 1)
        {
            cam.cinema.transform.eulerAngles = new Vector3(90,0,0);
            cam.cinema.m_Lens.FieldOfView = 75;
            CinemachineComponentBase componentBase = cam.cinema.GetCinemachineComponent(CinemachineCore.Stage.Body);
            if (componentBase is CinemachineFramingTransposer)
            {
                (componentBase as CinemachineFramingTransposer).m_CameraDistance = 10;
            }
            lait = LightManager.instance;
            lait.gameObject.SetActive(false);
            rgo = Instantiate(obj);
            rgo.GetComponent<RacoonBodyObj>().us = this;
            for (int i = 0; i < 7; i++)
            {
                SpawnPoints();
            }
            var g = al[0].transform;
            o = Instantiate(player, new Vector3(g.position.x, 1, g.position.z),Quaternion.identity);
            canvas.canvasObject.SetActive(false);
            for (int i = 0; i < al.Count; i++)
            {
                ally.allAllyCharacters[i].SetActive(false);
            }
            al.Add(o);
            garbageCollector.Add(o);
            ForList.Swap(al, 0, al.Count - 1);
            for (int i = 0; i < e.Count; i++)
            {
                EnmyIns(i);
                e[i].SetActive(false);
            }
        }
    }
    public void EnmyIns(int i)
    {
        var a = Instantiate(enemys, new Vector3(e[i].transform.position.x, 1, e[i].transform.position.z), Quaternion.identity);
        garbageCollector.Add(a);
        int ran = Random.Range(1, mat.Count);
        a.GetComponent<MeshRenderer>().material = mat[ran];
        var s = a.GetComponent<DefaultMovementForEnemy>();
        a.GetComponent<DefaultMovementForEnemy>().vector = o.transform.position ;
        s.number = ran;
        s.obj = rgo.GetComponent<RacoonBodyObj>();
    }
    public override void GameOver()
    {
        base.GameOver();
        Destroy(rgo);
        cam.gameObject.SetActive(true);
        ally.allAllyCharacters.Remove(o);
        for (int i = 0; i < garbageCollector.Count; i++)
        {
            Destroy(garbageCollector[i]);
        }
        for (int i = 0; i < al.Count; i++)
        {
            al[i].SetActive(true);
            al[i].GetComponent<Rigidbody>().isKinematic = false;
            al[i].transform.position = new Vector3(al[i].transform.position.x,0.6f, al[i].transform.position.z);
            // можно добавить условие
            var a = al[i].GetComponent<ArrowMovement>();
            a.w = false;
            a.s = false;
            a.a = false;
            a.d = false;
        }
        for (int i = 0; i < e.Count; i++)
        {
            e[i].SetActive(true);
        }
        cam.cinema.transform.eulerAngles = new Vector3(53, 0, 0);
        cam.cinema.m_Lens.FieldOfView = 40;
        CinemachineComponentBase componentBase = cam.cinema.GetCinemachineComponent(CinemachineCore.Stage.Body);
        if (componentBase is CinemachineFramingTransposer)
        {
            (componentBase as CinemachineFramingTransposer).m_CameraDistance = 10;
        }
        canvas.canvasObject.SetActive(true);
        lait.gameObject.SetActive(true);
        gameObject.SetActive(false);
    }
    public override void Win()
    {
        GameOver();
        for (int i = 0; i < e.Count; i++)
        {
            Destroy(e[i]);
        }
        e.Clear();
    }
    void SpawnPoints()
    {
        int q = Random.Range(1, 5);
        print(q);
        float transP = Random.Range(6, 12);
        float transM = Random.Range(-6, -12);
        var obj = Instantiate(points, ally.allAllyCharacters[0].transform.position,Quaternion.identity);
        obj.GetComponent<DefaultPoints>().obj = rgo.GetComponent<RacoonBodyObj>();
        garbageCollector.Add(obj);
        switch (q)
        {
            case 1:
                obj.transform.position = new Vector3(transM,1,transP);
                break;
            case 2:
                obj.transform.position = new Vector3(transP, 1, transP);
                break;
            case 3:
                obj.transform.position = new Vector3( transP, 1, transM);
                break;
            case 4:
                obj.transform.position = new Vector3(transM, 1, transM);
                break;

        }
    }
}