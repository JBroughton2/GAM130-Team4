using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class JornalScript : MonoBehaviour
{
    public GameObject jornalCanvas;
    public GameObject hudCanvas;
    public Text LogText;


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

    

    public void Log1()
    {

        LogText.text = string.Format("The final part’s going to be put in today, who knew the luciferins in bioluminescent mushrooms could be used to power a whole city! " +
            "Centraal came down and built a storage facility for it; it’s got this weird security system attached to it, none of us are allowed inside ");

    }

    public void Log2()
    {

        LogText.text = string.Format("I don’t know what kind of crazy technology they're using to keep that thing " +
            "running but it’s causing our power output to skyrocket- That bulb in the plant lab that’s always starts flickering after it’s been on for a few hours? " +
            "It’s now the brightest bulb in the room. I think it’s making the incubator lights brighter too, the specimens appear to be growing  at a rapid pace; " +
            "I’m worried we’re going to run out of tanks to keep them in. ");

    }

    public void Log3()
    {

        LogText.text = string.Format("The water in dome 2 has changed colour, we’re trying to work out what’s causing it. I think it's because this brighter lighting is causing more dark algae blooms, " +
            "but they’re not letting any unauthorised scientists in to investigate. I’ve heard rumours that the mushroom samples in there have been growing at a rapid rate; " +
            "I wonder if it’s got something to do with the water... ");

    }

}
