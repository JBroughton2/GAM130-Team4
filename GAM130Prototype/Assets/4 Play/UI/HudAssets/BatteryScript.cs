using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;


public class BatteryScript : MonoBehaviour
{
    public int batteries = 5;
    public Text powerLevelText;
    public float decreaseAmmount = 0.1f;
    public bool torchUsed = false;
    public float DelayTime = 0.1f;
    public float displayCharge;
    public ResourceIcon battIcon;

    private bool batteryPickup = false;
    private int fullCharge = 100;
    private float currentCharge = 0;

    private Coroutine TimeDelayRoutine;
    public Action OnBattUpdate;


    private void Awake()
    {
        OnBattUpdate += (() => UpdateBattDisplay());
        UpdateBattDisplay();
    }

    private IEnumerator TimeDelay()
    {
        //Debug.Log("Before");
        yield return new WaitForSeconds(DelayTime);
        //Debug.Log("After");
        TimeDelayRoutine = null;
    }


    public void UpdateBattDisplay()
    {
        battIcon.UpdateValue(batteries);
    }


    private void AddBattery() 
    {       
        batteries += 1;
        batteryPickup = false;
        OnBattUpdate.Invoke();
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
                currentCharge = currentCharge - decreaseAmmount * Time.deltaTime ;
                if (TimeDelayRoutine == null)
                    TimeDelayRoutine = StartCoroutine(TimeDelay());
            }
        }
    }

    private void ChangeBattery()
    {
        batteries -= 1;

        currentCharge = fullCharge;
        OnBattUpdate.Invoke();
    }
    
    


    void Update()
    {
        if (batteryPickup) AddBattery();
        
        UsePower();

        //Debug.Log(currentCharge);
        // need to display battery percentage in the text next to lightning bolt rounding within 5%? or to full number

        //displayText.text = varname+"%";
        displayCharge = currentCharge / fullCharge * 100;
        powerLevelText.text = Math.Round(displayCharge, 2) +"%";
    }
}
