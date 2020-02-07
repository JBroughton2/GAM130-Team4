using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardAlphas : MonoBehaviour
{
   public bool redCardFound = false;
   public bool greenCardFound = true;
    
    [SerializeField]
    private Image Greencard;
    [SerializeField]
    private Image Redcard;

    

    private void checkCardsFound()
    {
        if (greenCardFound)
        {
            Color greenC = Greencard.color;
            greenC.a = 1f;
            Greencard.color = greenC;
        }

        if (redCardFound)
        {
            Color redC = Redcard.color;
            redC.a = 1f;
            Redcard.color = redC;
        }
    }


    

    // Update is called once per frame
    void Update()
    {
        checkCardsFound();
        
    }
}
