using System.Collections.Generic;
using UnityEngine;
public class EnemyCharacters : MonoBehaviour
{
    public static EnemyCharacters instance;
    public List<GameObject> allEnemyCharacters = new List<GameObject>();
    public List<GameObject> allVisual = new List<GameObject>();
    public LayerMask mask;
    private void Awake()
    {
        instance = this;
    }
    public void RemoveAll()
    {
        for (int j = 0; j < allVisual.Count; j++)
        {
            Destroy(allVisual[j]);
            allVisual.RemoveAt(j);
        }
    }
}