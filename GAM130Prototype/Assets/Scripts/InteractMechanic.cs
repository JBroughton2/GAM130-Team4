using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMechanic : MonoBehaviour
{
    public bool canPick;
    public GameObject uiPick;
    public GameObject uiInteract;
    public Animator viewMod;
    public bool Animating;

    // Use this for initialization
    void Start()
    {
        canPick = false;
        //uiPick.SetActive(false);
        viewMod = GameObject.Find("ViewModelIdle").GetComponent<Animator>();
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if (Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            Debug.DrawRay(transform.position, transform.forward * 3f, Color.red);

            if (hit.collider.GetComponent<PickedObject>() != null)
            {
                canPick = true;
                uiPick.SetActive(true);
                

                Debug.Log("PickUp");
            }
            else
            {
                uiPick.SetActive(false);

                canPick = false;
            }


            if (hit.collider.GetComponent<InteractableButton>() != null)
            {
                //hit.collider.GetComponent<InteractableButton>().buttonClicked = true;
                uiInteract.SetActive(true);
                //viewMod.SetTrigger("Push");

                Debug.Log("Interactable");
            }
            else
            {
                uiInteract.SetActive(false);
            }

            if (Input.GetMouseButtonDown(0) && canPick == true && Animating == false)
            {
                hit.collider.GetComponent<PickedObject>().IsPickedUp = true;
                Destroy(hit.transform.gameObject);
                viewMod.SetTrigger("Grab");
                StartCoroutine(ResetAction());
                Animating = true;
                //Add something to the resources value when we have them added. I plan to use enums for different objects

            }
        }
        else if (Input.GetMouseButtonDown(0) && Animating == false)
        {
            viewMod.SetTrigger("Punch");
            StartCoroutine(ResetAction());
            Animating = true;
        }


    }

    IEnumerator ResetAction()
    {
        yield return new WaitForSeconds(0.4f);

        viewMod.ResetTrigger("Punch");

        viewMod.ResetTrigger("Push");

        viewMod.ResetTrigger("Grab");

        Animating = false;


    }
    void Land()
    {
        viewMod.ResetTrigger("Jump");


    }
}
