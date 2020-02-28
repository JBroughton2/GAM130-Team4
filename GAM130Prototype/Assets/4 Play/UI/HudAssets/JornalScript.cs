using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JornalScript : MonoBehaviour
{
    public GameObject jornalCanvas;
    public GameObject hudCanvas;

    private void changeHudState()
    {
        if (jornalCanvas.activeInHierarchy == true)
        {
            jornalCanvas.SetActive(false);
            hudCanvas.SetActive(true);
        }
        else
        {
            jornalCanvas.SetActive(true);
            hudCanvas.SetActive(false);
        }
    }

    void Update()
    {
        if (Input.GetKeyUp("j"))
        {
            changeHudState(); 
        }
    }



}
