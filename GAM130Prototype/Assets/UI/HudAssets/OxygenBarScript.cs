using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OxygenBarScript : MonoBehaviour
{
    bool decreasing = true;
    float oxygen = (float)1.0;
    float Ammount_Decrease = (float)0.0005;
   
    private void Nothing() {

    }

    
    private void Update()
    {
        
        if ((oxygen > Ammount_Decrease) && (decreasing = true))
        {
            oxygen = oxygen - Ammount_Decrease;

            Transform bar = transform.Find("Bar");
            bar.localScale = new Vector3(oxygen, 1f);

            Invoke("Nothing", 0.1f);
        }




    }
}
