using UnityEngine;
public class Spawner : Building
{
    public GameObject obj;
    public float time;
    float curTime;
    public void Update()
    {
        curTime -= Time.deltaTime;
        if (curTime<=0)
        {
            if(obj!=null)
                Instantiate(obj,transform);
                
            curTime = time;
        }
    }
}