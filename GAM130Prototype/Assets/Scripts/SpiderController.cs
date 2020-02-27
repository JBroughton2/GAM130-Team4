using System.Collections;
using UnityEngine;
using UnityEngine.AI;

public class SpiderController : MonoBehaviour
{
    [SerializeField] private Transform target;
    [SerializeField] private Animator anim;
    private NavMeshAgent navMesh;

    private bool inPLay = false;
    private bool attacking;
 
    void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();

        StartCoroutine(checkFinishedEmergeAnimation());
    }

    IEnumerator checkFinishedEmergeAnimation()
    {
        while ((!anim.GetCurrentAnimatorStateInfo(0).IsName("DigEmerge"))){
            yield return new WaitForEndOfFrame();
        }

        inPLay = true;
    }


    void Update()
    {

        if (inPLay)
        {
            Vector3 newTargetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
            navMesh.destination = newTargetPostition;
            anim.SetBool("WalkForwards", true);
            if (attacking)
            {
                anim.SetBool("Attack", false);
                attacking = false;
            }

        }

    }

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Triggered");
            anim.SetBool("Attack", true);
            attacking = true;
        }
    }
}