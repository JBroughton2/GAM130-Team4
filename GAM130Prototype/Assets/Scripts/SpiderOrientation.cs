using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SpiderOrientation : MonoBehaviour
{
    public Transform[] points;
    private int destPoint = 0;
    private NavMeshAgent agent;
    [SerializeField] private Animator anim;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        agent.autoBraking = false;
        GotoNextPoint();
    }

    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;
        anim.SetBool("WalkForwards", true);

        StartCoroutine(PointDelay());
    }

    void Update()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            StartCoroutine(PointDelay());
        }

    }

    IEnumerator PointDelay()
    {
        if (!agent.pathPending && agent.remainingDistance < 0.5f)
        {
            yield return new WaitForSeconds(10);
        }
        Debug.Log("Pause");
        GotoNextPoint();
    }
}
