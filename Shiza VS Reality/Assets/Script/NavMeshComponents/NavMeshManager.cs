using UnityEngine;
using System.Collections.Generic;
using UnityEngine.AI;
public class NavMeshManager : MonoBehaviour
{
    private NavMeshSurface surface;
    public NavMeshManager instance=>this;
    private void Start()
    {
        surface = GetComponent<NavMeshSurface>();
        BuildNavMesh();
    }
    [ContextMenu("")]
    public void BuildNavMesh()
    {
        surface.BuildNavMesh();
    }
}