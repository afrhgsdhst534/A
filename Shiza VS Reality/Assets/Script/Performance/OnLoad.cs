using UnityEngine;
using System.Collections.Generic;
public class OnLoad : MonoBehaviour
{
    public List<string> onAwakeP;
    public List<string> onStartP;
    public static OnLoad instance;
    private void Awake()
    {
        instance = this;
        for (int i = 0; i < onAwakeP.Count; i++)
        {
            CreatePrefab(onAwakeP[i]);
        }
    }
    void Start()
    {
        for (int i = 0; i < onStartP.Count; i++)
        {
            CreatePrefab(onStartP[i]);
        }
    }
    void CreatePrefab(string path)
    {
        GameObject prefab = Resources.Load<GameObject>(path);
        Instantiate(prefab);
    }
}