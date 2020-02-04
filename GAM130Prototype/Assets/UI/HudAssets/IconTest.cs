using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IconTest : MonoBehaviour
{
    public GameObject icon1Object;
    public int displayAmount = 30;

    private ResourceIcon icon1;

    // Start is called before the first frame update
    void Start()
    {
        icon1 = icon1Object.GetComponent<ResourceIcon>();

    }

    // Update is called once per frame
    void Update() 
    {

        icon1.UpdateValue(displayAmount);   
    }
}
