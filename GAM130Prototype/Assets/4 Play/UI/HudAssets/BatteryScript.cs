using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BatteryScript : MonoBehaviour
{
    public double decreaseAmmount = (double)0.1;
    public bool torchUsed = false;
    public float DelayTime = 0.1f;
    public double displayCharge;

    private bool batteryPickup = false;
    private int batteries = 5;
    private int fullCharge = 100;
    private double currentCharge = (double)0;

    private Coroutine TimeDelayRoutine;


    private IEnumerator TimeDelay()
    {
        //Debug.Log("Before");
        yield return new WaitForSeconds(DelayTime);
        //Debug.Log("After");
        TimeDelayRoutine = null;
    }



    private void AddBattery() 
    {       
        batteries += 1;
        batteryPickup = false;
        
    } 

    private void UsePower() 
    {
        if (torchUsed)
        { 

            if (currentCharge <= 0)
            {
                ChangeBattery(); 
            }

            else
            {
                currentCharge = currentCharge - decreaseAmmount;
                if (TimeDelayRoutine == null)
                    TimeDelayRoutine = StartCoroutine(TimeDelay());
            }
        }

        

    }

    private void ChangeBattery()
    {
        batteries -= 1;

        currentCharge = fullCharge;
    }
    
    


    void Update()
    {
        if (batteryPickup) AddBattery();
        
        UsePower();

        Debug.Log(currentCharge); 
        // need to display battery percentage in the text next to lightning bolt rounding within 5%? or to full number

    }
}
