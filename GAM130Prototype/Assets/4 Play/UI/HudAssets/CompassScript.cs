using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{

    public GameObject clock;

    private float rotateAmount;
    
 
    Vector3 dir;
    
    private void Update()
    {
        rotateAmount = clock.GetComponent<ClockScript>().getRotateAmount();
        Debug.Log(rotateAmount);

        
        dir.z = rotateAmount;
        transform.localEulerAngles = dir;
    }


    

}
