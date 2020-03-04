using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{
    public int dayLength = 360;
    public float rotateAmount;
    public float interval;
    Vector3 dir;
    
    private void Update()
    {
        interval = - dayLength / 360 * Time.deltaTime;


        rotateAmount = rotateAmount + interval;
        dir.z = rotateAmount;

        transform.localEulerAngles = dir;
    }


    

}
