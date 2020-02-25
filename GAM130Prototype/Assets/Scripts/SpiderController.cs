using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    [SerializeField]
    private Transform target;
    [SerializeField]
    private Animator anim;

    private NavMeshAgent navMesh;
    Vector3 lastFacing = Vector3.zero;


    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        lastFacing = transform.forward;
    }

    void Update()
    {

        navMesh.destination = target.position;

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            anim.SetBool("Moving", true);
        }

        Vector3 currentFacing = transform.forward;
        float currentAngularVelocity = Vector3.Angle(currentFacing, lastFacing) / Time.deltaTime; //degrees per second
        lastFacing = currentFacing;

        bool isRotating = currentAngularVelocity > 1f;
    }
}
