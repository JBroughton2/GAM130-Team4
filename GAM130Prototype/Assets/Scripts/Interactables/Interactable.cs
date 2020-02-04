using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Outline m_outline = null;

    // Start is called before the first frame update
    protected void Start()
    {
        m_outline = GetComponent<Outline>();
        if (m_outline != null) m_outline.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public virtual void OnPlayerHighlight()    
    {        
        if (m_outline != null) m_outline.enabled = true;
    }

    public virtual void OnPlayerUnHighlight()
    {
        if (m_outline != null) m_outline.enabled = false;
    }

    public virtual void OnPlayerInteract()
    {

    }
}
