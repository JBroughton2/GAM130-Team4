using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableButton : Interactable
{
    //prevents the button from being interacted with again for this many seconds
    //ideally should be longer than any animations associated with it
    public float m_interactCooldown = 5f;
    bool m_canInteract = true;
    IEnumerator interactCooldown()
    {
        yield return new WaitForSeconds(m_interactCooldown);
        m_canInteract = true;
    }    

    void Start()
    {
        
    }

    public override void OnPlayerInteract()
    {
        base.OnPlayerInteract();

        if (m_canInteract)
        {
            m_canInteract = false;
            StartCoroutine(interactCooldown());

            //do button animation

            //do player animation

            //trigger button event
        }
    }
}
