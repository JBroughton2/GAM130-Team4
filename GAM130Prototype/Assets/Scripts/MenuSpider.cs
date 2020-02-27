using UnityEngine;
using UnityEngine.AI;
using System.Collections;
using System.Collections.Generic;

public class MenuSpider : MonoBehaviour
{
    private Animator anim;
    public List<Transform> waypoints = new List<Transform>();
    private Transform targetWaypoint;
    private int targetWaypointIndex = 0;
    private float minDistance = 0.1f;
    private float lastWaypointIndex;

    [SerializeField]
    private float speed = 3.0f;

    void Start()
    {
        targetWaypoint = waypoints[targetWaypointIndex];
        anim = GetComponentInChildren<Animator>();
    }

    void Update()
    {
        float movement = speed * Time.deltaTime;
        //CheckWaypointDistance(distance);
        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, movement);

        anim.SetBool("WalkForwards", true);
    }

    //void CheckWaypointDistance (float currentDistance)
   // {
   //     if(currentDistance <= minDistance)
   //     {
    //        targetWaypointIndex++;
    //        UpdateTargetWaypoint();
    //    }
   // }

}
