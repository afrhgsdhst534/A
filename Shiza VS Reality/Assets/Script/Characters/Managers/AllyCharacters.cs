using System.Collections.Generic;
using UnityEngine;
public class AllyCharacters : MonoBehaviour
{
    public static AllyCharacters instance;
    public List<GameObject> allAllyCharacters = new List<GameObject>();
    public List<GameObject> selectedAllyCharacters = new List<GameObject>();
    public GameObject selectedVisualize;
    public List<GameObject> allVisual = new List<GameObject>();
    public LayerMask mask;
    public LayerMask ground;
    public LayerMask UI;
    public void Awake()
    {
        instance = this;
    }
    public void RemoveAll()
    {
        selectedAllyCharacters.Clear();
        for (int j = 0; j < allVisual.Count; j++)
        {
            Destroy(allVisual[j]);
            allVisual.RemoveAt(j);
            selectedAllyCharacters.AddRange(new List<GameObject>());
        }
    }
    public void VisualCreate(GameObject gO)
    {
       GameObject sV =  Instantiate(selectedVisualize, gO.transform);
        allVisual.Add(sV);
    }
}