//using UnityEngine;
//using UnityEngine.AI;
//using System.Collections;
//using System.Collections.Generic;


//public class SpiderPatrol : MonoBehaviour
//{
//    public NavMeshAgent agent;
//    public GameObject spider;
//    public enum State
//    {
//        PATROL,
//        CHASE
//    }

//    public State state;
//    private bool alive;

//    // Variables for Patrolling
//    public GameObject[] waypoints;
//    private int waypointIndex = 0;
//    public float patrolSpeed = 0.5f;

//    // Variables for Chasing
//    public float chaseSpeed = 1f;
//    public GameObject target;

//    void Start()
//    {
//        agent = GetComponent<NavMeshAgent>();

//        agent.updatePosition = true;
//        agent.updateRotation = false;

//        state = SpiderPatrol.State.PATROL;
//        alive = true;

//        StartCoroutine("FSM");
//    }

//    IEnumerator FSM()
//    {
//        while (alive)
//        {
//            switch (state)
//            {
//                case State.PATROL:
//                    Patrol();
//                    break;
//                case State.CHASE:
//                    Chase();
//                    break;
//            }
//            yield return null;
//        }
//    }

//    void Patrol()
//    {
//        agent.speed = patrolSpeed;
//        if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) >= 2)
//        {
//            agent.SetDestination(waypoints[waypointIndex].transform.position);
//            CharacterController.Move(agent.desiredVelocity, false, false);
//        }
//        else if (Vector3.Distance(this.transform.position, waypoints[waypointIndex].transform.position) <= 2)
//        {
//            waypointIndex += 1;
//            if (waypointIndex > waypoints.Length)
//            {
//                waypointIndex = 0;
//            }
//        }
//        else
//        {
//            spider.Move(Vector3.zero, false, false);
//        }
//    }

//    void Chase()
//    {
//        agent.speed = chaseSpeed;
//        agent.SetDestination(target.transform.position);
//        CharacterController.Move(agent.desiredVelocity, false, false);
//    }

//    void OnTriggerEnter (Collider coll)
//    {
//        if (coll.tag == "Player")
//        {
//            state = SpiderController.State.CHASE;
//            target = coll.gameObject;
//        }
//    }
//}
