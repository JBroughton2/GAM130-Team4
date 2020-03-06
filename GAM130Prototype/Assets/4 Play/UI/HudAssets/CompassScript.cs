using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CompassScript : MonoBehaviour
{

    [Range (0,1200)]
    public int lengthOfDay = 360;
    public float rotateAmount;
    public float interval;
    Vector3 dir;
    
    private void Update()
    {
        interval = -(360 / lengthOfDay);  //rull rotation(360) / daylength = rotate interval
        Debug.Log(interval);
        interval = interval * Time.deltaTime;


        rotateAmount = rotateAmount + interval;
        dir.z = rotateAmount;

        transform.localEulerAngles = dir;
    }


    

}
