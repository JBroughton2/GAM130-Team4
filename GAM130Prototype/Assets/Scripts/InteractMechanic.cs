using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractMechanic : MonoBehaviour
{
    public GameObject interactUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(transform.position, transform.forward, out hit, 3f))
        {
            Debug.DrawRay(transform.position, transform.forward * 3f, Color.red);
            if (hit.collider != null)
            {
                interactUI.SetActive(true);
            }
            else
            {
                interactUI.SetActive(false);
            }
        }
    }
}
