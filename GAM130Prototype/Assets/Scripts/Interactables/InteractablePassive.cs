using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePassive : Interactable
{
    public bool m_debug = false;

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
}
