using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickUp : Interactable
{
    public bool m_debug = false;
    public bool m_canPickup = true;

    void Start()
    {
        base.Start();
    }

    protected override void OnHighlight()
    {
        base.OnHighlight();
        
        if(m_debug) Debug.Log("highlight");        
    }

    protected override void OnUnHighlight()
    {
        base.OnUnHighlight();
        
        if(m_debug) Debug.Log("un-highlight");
    }

    public override void OnPlayerInteract()
    {
        base.OnPlayerInteract();

        
        if ((Input.GetKeyDown(KeyCode.E)) && m_canPickup)
        {
            m_canPickup = false;
            Debug.Log("PickedUp");
        }
    }

    public void drop()
    {
        m_canPickup = true;
        Debug.Log("Dropping");
    }
}
