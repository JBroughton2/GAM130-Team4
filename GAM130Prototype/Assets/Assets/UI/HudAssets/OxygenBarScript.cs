using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OxygenBarScript : MonoBehaviour
{
    bool decreasing = true;
    public float maxOxygen = 100;
    private float oxygen = (float)100;
    [Range(0.1f, 100)]
    public float Ammount_Decrease = (float)1;
    public float nothingDelayTime = 0.1f;
    public Image fillBar;
    [Range(1,100)]
    public int addAmount = 30;

    private Coroutine TimeDelayRoutine;

    void Awake()
    {
        oxygen = maxOxygen;
    }

    private IEnumerator TimeDelay() 
    {
        //Debug.Log("Before");
        yield return new WaitForSeconds(nothingDelayTime);
        //Debug.Log("After");
        TimeDelayRoutine = null;
    }

    private void addOxygen() 
    {
        if (oxygen + addAmount > maxOxygen)
            oxygen = maxOxygen;
        else
            oxygen = oxygen + addAmount;
    }

    
    private void Update()
    {
        
        if ((oxygen > 0) && (decreasing = true))
        {
            oxygen = oxygen - Ammount_Decrease * Time.deltaTime;

            fillBar.fillAmount = oxygen / maxOxygen;

            if (TimeDelayRoutine == null)
                TimeDelayRoutine = StartCoroutine(TimeDelay());
        }


    }
}
