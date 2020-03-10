using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClockScript : MonoBehaviour
{
    [Range(0.1f, 1200)]
    public float dayLength = 60f;

    private float timeOfDay;
    private float startOfDay;
    private int daysPassed;
    private float rotateAmount; 


    
    //day length 6 mins 
    void Start()
    {
        timeOfDay = 0;
        daysPassed = 0;
        rotateAmount = 0;

        startOfDay = Time.time;
    }

    public float getRotateAmount()
    {
        return rotateAmount;
    }
    
    void Update()
    {
        timeOfDay = Time.time - startOfDay;

        if (timeOfDay >= dayLength)
        {
            daysPassed += 1;            
            timeOfDay -= dayLength;
            startOfDay = Time.time - timeOfDay;
        }

        rotateAmount = -(360f / dayLength) * timeOfDay;


        // add hours and minutes here.

    }
}
