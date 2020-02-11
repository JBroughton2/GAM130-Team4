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
        navMesh.destination = target.position;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetBool("Moving", true);
        }
    }
}
