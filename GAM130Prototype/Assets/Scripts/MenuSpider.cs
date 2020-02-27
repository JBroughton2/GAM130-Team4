using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class MenuSpider : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent navMesh;

    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        navMesh.autoBraking = false;
        GotoNextPoint();
    }

    void Update()
    {
        if (!navMesh.pathPending && navMesh.remainingDistance < 0.5f)
            GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        destPoint = (destPoint + 1) % points.Length;
    }
}
