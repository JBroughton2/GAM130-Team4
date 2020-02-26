using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Animator anim;

    private NavMeshAgent navMesh;


    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        Vector3 newTargetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        navMesh.destination = newTargetPostition;

    }
}