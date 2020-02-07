using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractablePickUp : Interactable
{
    public bool m_debug = false;
    public bool m_canPickup = true;
    [SerializeField]
    private Transform pickUpPos;
    [SerializeField]
    private float throwForce;
    private Rigidbody rb;

    void Start()
    {
        base.Start();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if ((Input.GetMouseButtonDown(1) && !m_canPickup))
        {
            Throw();
        }
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
            transform.position = pickUpPos.position;
            this.transform.SetParent(pickUpPos);
            rb.isKinematic = true;
            Debug.Log(pickUpPos.position);
            Debug.Log("PickedUp");
        }
    }

    public void drop()
    {
        m_canPickup = true;
        rb.isKinematic = false;
        this.transform.SetParent(null);
        Debug.Log("Dropping");
    }

    public void Throw()
    {
        m_canPickup = true;
        rb.isKinematic = false;
        this.transform.SetParent(null);
        rb.AddForce(transform.forward * throwForce);
    }

}
