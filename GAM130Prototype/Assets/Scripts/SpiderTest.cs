//using UnityEngine;
//using System;
//using System.Collections;
//using UnityEngine.AI;

//public class SpiderController : MonoBehaviour
//{
//    public NavMeshAgent navMesh;   // The nam mesh agent that is connected to the spider.
//    public enum State
//    {
//        PATROL,
//        CHASE,
//        ATTACK
//    }
//    public State state;
//    private bool alive;

//    // Variables for Patrolling
//    public GameObject[] wayPoints;
//    private int wayPointIndex = 0;
//    public float patrolSpeed = 0.5f;

//    //Variables for Chasing
//    public float chaseSpeed = 1f;
//    public GameObject target;

//    void Start()
//    {
//        navMesh = GetComponent<NavMeshAgent>();

//        navMesh.updatePosition = true;
//        navMesh.updateRotation = false;

//        state = SpiderController.State.PATROL;
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
//                case State.CHASE;
//                    Chase();
//                    break;
//                case State.ATTACK;
//                    Attack();
//                    break;
//            }
//            yield return null;
//        }
//    }

//    void Patrol()
//    {
//        navMesh.speed = patrolSpeed;
//        if (Vector3.Distance(this.transform.position, wayPoints[wayPointIndex].transform.position) >= 2)
//        {
//            navMesh.SetDestination(wayPoints[wayPointIndex].transform.position);
//        }
//    }

//    void Chase()
//    {

//    }

//    void Attack()
//    {

//    }

//    void OnTriggerEnter(Collider coll)
//    {

//    }
//}
