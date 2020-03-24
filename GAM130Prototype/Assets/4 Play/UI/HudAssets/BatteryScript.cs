using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEditor.Events;
using System.Globalization;


public class BatteryScript : MonoBehaviour
{
    public int batteries = 5;
    [Range (0.1f,20)]
    public float decreaseAmmount = 0.1f;
    public bool torchUsed = false;    
    public float displayCharge;
    private bool batteryPickup = false;
    private int fullCharge = 100;
    private float currentCharge = 0;
    private string StrDisplayCharge;

    
    public Action OnBattUpdate;
    public Text powerLevelText;
    public ResourceIcon battIcon;


    private void Awake()
    {
        OnBattUpdate += (() => UpdateBattDisplay());
        UpdateBattDisplay();
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
        if ( batteries == 0  && currentCharge <= 0)
        {
            currentCharge = 0;
        }
        else {
            if (torchUsed)
            {

                if (currentCharge <= 0)
                {
                    ChangeBattery();
                }

                else
                {
                    currentCharge = currentCharge - decreaseAmmount * Time.deltaTime;                    
                }
            }
        }
    }

    private void ChangeBattery()
    {
        if (batteries == 0)
        {
            //stop flashlight
            Debug.Log("stop flashlight");
        }

        if (batteries > 0)
        {
            batteries -= 1;
        }
        
        currentCharge = fullCharge;
        OnBattUpdate.Invoke();
    }




    void Update()
    {
        if (batteryPickup) AddBattery();

        UsePower();

        
        // need to display battery percentage in the text next to lightning bolt rounding within 5%? or to full number

        
        displayCharge = currentCharge / fullCharge * 100;

        StrDisplayCharge = displayCharge.ToString("0.0", CultureInfo.InvariantCulture);
        powerLevelText.text = StrDisplayCharge + "%";
    }
}
