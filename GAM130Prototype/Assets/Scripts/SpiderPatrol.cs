using UnityEngine;
using UnityEngine.AI;
using System.Collections;

public class SpiderPatrol : MonoBehaviour
{
    // Waypoints
    public Transform[] points;
    private int destPoint = 0;

    // Referencing things
    [SerializeField] private Animator anim;
    private NavMeshAgent agent;
    private Transform target;
    private PlayerHealth playerHealth;

    // Radius for chasing and attacking.
    public float chaseRadius = 25f;
    public float attackRadius = 10f;

    // Attacking values
    public float timeBetweenAttacks = 0.5f;
    public int attackDamage = 10;

    // Booleans
    public bool isNearbyPlayer;
    public bool readyToAttack;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        anim = GetComponentInChildren<Animator>();
        playerHealth = playerHealth.GetComponent<PlayerHealth>();

        agent.autoBraking = false;
        GotoNextPoint();
    }

    // Function which makes patrolling spiders travel between waypoints.
    void GotoNextPoint()
    {
        if (points.Length == 0)
            return;
        agent.destination = points[destPoint].position;

        destPoint = (destPoint + 1) % points.Length;

        anim.SetBool("WalkForwards", true);

    }

    void FixedUpdate()
    {
        isNearbyPlayer = IsPlayerNear();
        readyToAttack = playerInRange();

        if (!agent.pathPending && agent.remainingDistance < 0.5f && !isNearbyPlayer && !readyToAttack)
        {
            StartCoroutine(PointDelay());
        }
        if (isNearbyPlayer && !readyToAttack)
        {
            Chase();
        }
        if (readyToAttack)
        {
            Attack();
        }
    }

    IEnumerator PointDelay()
    {
        anim.SetBool("WalkForwards", false);
        yield return new WaitForSeconds(7);
        GotoNextPoint();
    }

    // Function to make spider chase plaer when close.
    void Chase()
    {
        Vector3 newTargetPostition = new Vector3(target.position.x, this.transform.position.y, target.position.z);
        agent.destination = newTargetPostition;
    }

    // Function for spider to attack player when close.
    void Attack()
    {
        anim.SetBool("Attack", true);
        if (playerHealth.currentHealth > 0)
        {
            playerHealth.TakeDamage(attackDamage);
            Debug.Log("Taking player health.");


        }
    }

    // Seeing if the player is close enough to the spider.
    bool IsPlayerNear()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, chaseRadius);
        foreach (Collider item in nearbyObjects)
        {
            if (item.CompareTag("Player"))
            {
                target = item.transform;
                return true;
            }
        }

        return false;
    }

    // Seeing if player is close enough to spider to be attacked.
    bool playerInRange()
    {
        Collider[] nearbyObjects = Physics.OverlapSphere(transform.position, attackRadius);
        foreach (Collider item in nearbyObjects)
        {
            if (item.CompareTag("Player"))
            {
                target = item.transform;
                return true;
            }
        }

        return false;
    }

    // Creates a red radius around character.
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(this.transform.position, chaseRadius);

        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(this.transform.position, attackRadius);
    }
}