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

    public override void OnPlayerHighlight()
    {
        base.OnPlayerHighlight();
        
        if(m_debug) Debug.Log("highlight");        
    }

    public override void OnPlayerUnHighlight()
    {
        base.OnPlayerUnHighlight();
        
        if(m_debug) Debug.Log("un-highlight");
    }
}
