using UnityEngine;
using System.Collections.Generic;
using MyTools;
public class RealityChangerList : AList
{
    AllyCharacters ally;
    List<GameObject> obj;
    const string path = "Shop";
    private void Start()
    {
        ally = AllyCharacters.instance;
        obj =ally.allAllyCharacters;
    }
    public override void Use(int i)
    {
        switch (i)
        {
            case 0:
                if(obj.Count>1)
                    ForList.Swap(obj,0,1);
                break;
            case 1:
                obj[0].GetComponent<RelativeObjs>().us.gameObject.SetActive(true);
                break;
            case 2:
                var a=  Instantiate(Resources.Load<GameObject>(path), new Vector3(obj[0].transform.position.x+2,0, obj[0].transform.position.z+2),Quaternion.identity);
                a.transform.eulerAngles = new Vector3(90,90,0);
                break;
        }
    }
}