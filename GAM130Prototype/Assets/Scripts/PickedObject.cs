using UnityEngine;
using System.Collections;

public enum Food
{
    FoodValue = 0,
    WaterValue = 1

};


public class PickedObject : MonoBehaviour
{
    public Food Name;
    private Rigidbody RB;
    private Coroutine coroutine;

    private bool isPickedup;
    public bool IsPickedUp
    {
        get { return isPickedup; }

        set
        {
            if (coroutine != null) StopCoroutine(coroutine);
            if (!value) coroutine = StartCoroutine(StartDelay());
            else if (value) isPickedup = value;
        }
    }
   
    private void Awake()
    {
        RB = this.GetComponent<Rigidbody>();
    }


    private IEnumerator StartDelay()
    {
        //print(RB.velocity.magnitude);

        yield return new WaitForSeconds(.5f);

        while (RB.velocity.magnitude > 0.25f)
        {
            yield return new WaitForEndOfFrame();
        }

        isPickedup = false;
    }
}
