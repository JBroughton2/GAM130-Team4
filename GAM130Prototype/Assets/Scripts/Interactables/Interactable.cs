using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Outline m_outline = null;

    //player controller
    protected static Animator m_playerAnimator = null;
    public static void setPlayerAnimator(Animator animator) { m_playerAnimator = animator; }

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

    bool m_isHighlighted = false;
    public void OnPlayerHighlight()    
    {
        m_isHighlighted = true;
        OnHighlight();
    }
    protected virtual void OnHighlight() {
        if (m_outline != null) m_outline.enabled = true;
    }

    public void OnPlayerUnHighlight()
    {
        m_isHighlighted = false;
        OnUnHighlight();
    }
    protected virtual void OnUnHighlight() {        
        if (m_outline != null) m_outline.enabled = false;
    }

    public virtual void OnPlayerInteract()
    {

    }
}
