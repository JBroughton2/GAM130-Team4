using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardsFound : MonoBehaviour
{
   public bool redCardFound = false;
   public bool greenCardFound = true;

    public GameObject iconsRegion;
    
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
        else
        {
            Color greenC = Greencard.color;
            greenC.a = 0.3f;
            Greencard.color = greenC;

        }

        if (redCardFound)
        {
            Color redC = Redcard.color;
            redC.a = 1f;
            Redcard.color = redC;
        }
        else
        {
            Color redC = Redcard.color;
            redC.a = 0.3f;
            Redcard.color = redC;

        }
    }


    

    // Update is called once per frame
    void Update()
    {     
        checkCardsFound();

        if (redCardFound || greenCardFound)
        {
            iconsRegion.SetActive(true);
        }
        else
        {
            iconsRegion.SetActive(false);
        }
    }
}
