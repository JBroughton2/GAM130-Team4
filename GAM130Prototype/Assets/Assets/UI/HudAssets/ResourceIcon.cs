using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ResourceIcon : MonoBehaviour
{
    public Image icon;
    public Text amountDisplay;

    public void UpdateValue(int amount) 
    {
        amountDisplay.text = string.Format("X {0}", amount);   
    }

    public void UpdateImage(Sprite newImage)
    {
        icon.sprite = newImage;
    } 
    
}
