using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SpiderPatrol : MonoBehaviour
{
    public Transform[] points;
    public float moveSpeed;

    private NavMeshAgent agent;
    private Transform target;

    private int maxDistance = 10;
    private int minDistance = 5;
    private int destPoint = 0;

    [SerializeField] 
    private float attackRadius;
    [SerializeField] 
    private Animator anim;

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

    }

    void Update()
    {
        bool isNearbyPlayer = IsPlayerNear();
        if (!agent.pathPending && agent.remainingDistance < 0.5f && !isNearbyPlayer)
        {
            StartCoroutine(PointDelay());
        }
        if (isNearbyPlayer)
        {
            Chase();
        }
    }

    IEnumerator PointDelay()
    {
        yield return new WaitForSeconds(10);
        GotoNextPoint();
        Debug.Log("Delaying");
    }

    void Chase()
    {
        Vector3 newTargetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        agent.destination = newTargetPostition;
        Debug.Log("Is Chasing");
    }

    bool IsPlayerNear()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider item in nearbyObjects)
        {
            Debug.Log(item);

            if (item.CompareTag("Player"))
            {
                target = item.transform;
                Debug.Log("Player near is true.");
                return true;
            }
        }
        return false;
    }
}