﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarScript : MonoBehaviour
{   
    public bool decreasing = true;
    public float maxOxygen = 100;
    private float oxygen = (float)100;
    [Range(0.1f, 100)]
    public float Ammount_Decrease = (float)1;
    public float DelayTime = 0.1f;
    public Image fillBar;
    [Range(1,100)]
    public int addAmount = 30;
    public float barAlpha = 0;

    private Coroutine AlphaRoutine;
    private Coroutine TimeDelayRoutine;
    public GameObject OxygenBar;

    bool increasingCurrent = false;
    bool decreasingCurrent = false;

    void Awake()
    {
        oxygen = maxOxygen;
        if (decreasing == true) barAlpha = 1f;
        else barAlpha = 0f; 
    }   

    IEnumerator lerpAlpha(float currentAlpha, float targetAlpha = 0f)
    {
        
        
        float length = 2f;
        float start = Time.time;
        float t = (Time.time - start) / length;

        float alpha;
        while (t < 1f)
        {
            alpha = Mathf.Lerp(currentAlpha, targetAlpha, t);



            Image[] barChildren = OxygenBar.GetComponentsInChildren<Image>();
            Color newColour;            
            foreach (Image child in barChildren)
            {
                newColour = child.color;
                newColour.a = alpha;
                child.color = newColour;                
            }

            yield return new WaitForEndOfFrame();
            t = (Time.time - start) / length;
            barAlpha = alpha;            
        }

        increasingCurrent = false;
        decreasingCurrent = false;
        yield return 0;
    }
    

    private IEnumerator TimeDelay() 
    {
        //Debug.Log("Before");
        yield return new WaitForSeconds(DelayTime);
        //Debug.Log("After");
        TimeDelayRoutine = null;
    }

    public void addOxygen() 
    {
        if (oxygen + addAmount > maxOxygen)
            oxygen = maxOxygen;
        else
            oxygen = oxygen + addAmount;
    }

    
    private void Update()
    {
        if ((oxygen >= maxOxygen && decreasing == false))
        {
            
            
            if (!increasingCurrent)
            {
                if (AlphaRoutine != null) StopCoroutine(AlphaRoutine);
                AlphaRoutine = StartCoroutine(lerpAlpha(barAlpha));
                increasingCurrent = true;
            }              
        }
        else
        {
            if (!decreasingCurrent)
            {
                if (AlphaRoutine != null) StopCoroutine(AlphaRoutine);
                AlphaRoutine = StartCoroutine(lerpAlpha(barAlpha, 1f));
                decreasingCurrent = true;
            }
        }


        if ((oxygen > 0) && (decreasing == true))
        {
            
            oxygen = oxygen - Ammount_Decrease * Time.deltaTime;

            fillBar.fillAmount = oxygen / maxOxygen;

            if (TimeDelayRoutine == null)
                TimeDelayRoutine = StartCoroutine(TimeDelay());
        }
        if ((oxygen < maxOxygen) && (decreasing == false)) 
        {
            oxygen = oxygen + Ammount_Decrease * 3 * Time.deltaTime;

            fillBar.fillAmount = oxygen / maxOxygen;

            if (TimeDelayRoutine == null)
                TimeDelayRoutine = StartCoroutine(TimeDelay());

        }
    }
}
