using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class FloorButton : MonoBehaviour
{
    public UnityEvent m_action;
    public UnityEvent m_reverseAction;

    public Animator m_buttonAnimator = null;

    public string[] m_triggerTags;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    bool checkTag(string tag)
    {
        bool foundTag = tag == "Player";
        for (int i = 0; i < m_triggerTags.Length && !foundTag; i++)
        {
            foundTag = tag == m_triggerTags[i];
        }

        return foundTag;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (checkTag(other.gameObject.tag))
        {
            m_action.Invoke();

            if (m_buttonAnimator != null) m_buttonAnimator.SetBool("Pressed", true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (checkTag(other.gameObject.tag))
        {
            m_reverseAction.Invoke();

            if (m_buttonAnimator != null) m_buttonAnimator.SetBool("Pressed", false);
        }
    }

}
