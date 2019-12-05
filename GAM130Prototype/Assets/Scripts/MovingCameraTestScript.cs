using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingCameraTestScript : MonoBehaviour
{
    public Transform truckCameraTransform;
    public Transform playerCameraTransform;
    public float enterDelay;
    public float leaveDelay;
    
    [SerializeField]
    private bool inTruck;
    [SerializeField]
    private Transform cameraTransform;


    private void Start()
    {
        inTruck = false;
        cameraTransform = GetComponent<Transform>();
    }

    private void Update()
    {     
        if (Input.GetKeyDown(KeyCode.E) && !inTruck)
        {
            EnterTruck();
            Debug.Log("Getting in the Truck");
        }
        else if (Input.GetKeyDown(KeyCode.E) && inTruck)
        {
            LeaveTruck();
            Debug.Log("Getting out Truck");
        }


    }

    /// <summary>
    /// This will change the players perspective to be in the front seat of the truck.
    /// </summary>
    private void EnterTruck()
    {
        inTruck = true;
        cameraTransform.position = truckCameraTransform.position;
        cameraTransform.rotation = truckCameraTransform.rotation;

    }

    /// <summary>
    /// This will move the players perspective back to the player who will be next to the drivers seat of the truck.
    /// </summary>
    private void LeaveTruck()
    {
        inTruck = false;
        cameraTransform.position = playerCameraTransform.position;
        cameraTransform.rotation = playerCameraTransform.rotation;
    }

    IEnumerator SlightDelayEnter()
    {
        yield return new WaitForSeconds(enterDelay);
        EnterTruck();
    }

    IEnumerator SlightDelayExit()
    {
        yield return new WaitForSeconds(leaveDelay);
        LeaveTruck();
    }
}
