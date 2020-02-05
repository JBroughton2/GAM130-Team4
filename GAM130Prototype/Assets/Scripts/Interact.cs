using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interact : MonoBehaviour
{
    public float m_reach = 5f;

    Interactable m_curInteractable = null;
    InteractablePickUp m_curPickup = null;

    PlayerInputHandler m_InputHandler;

    // Start is called before the first frame update
    void Start()
    {
        m_InputHandler = transform.parent.GetComponent<PlayerInputHandler>();
        if (m_InputHandler == null) Debug.Log("Input handler for Interact class is null, probably it can't find the component");
    }

    // Update is called once per frame
    void Update()
    {
        RaycastHit hit;
        bool raycastHit = Physics.Raycast(transform.position, transform.forward, out hit, m_reach);
        Interactable interactable = null;
        if (raycastHit)
        {
            interactable = hit.collider.GetComponent<Interactable>();
            if (interactable != null)
            {
                if(m_curInteractable != interactable)
                {
                    if (m_curInteractable != null) m_curInteractable.OnPlayerUnHighlight();
                    m_curInteractable = interactable;
                    m_curInteractable.OnPlayerHighlight();
                }
            }            
        }
        if((!raycastHit || interactable == null) && m_curInteractable != null)
        {
            m_curInteractable.OnPlayerUnHighlight();
            m_curInteractable = null;
        }

        if(m_curInteractable != null && m_InputHandler.GetInteractInputDown())
        {
            if(m_curPickup == null)
            {
                m_curInteractable.OnPlayerInteract();
                m_curPickup = m_curInteractable.gameObject.GetComponent<InteractablePickUp>();                
            }
            else
            {
                m_curPickup.drop();
                m_curPickup = null;
            }
            
        }
    }
}