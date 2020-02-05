using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class InteractableButton : Interactable
{
    [Tooltip("Use switch rather than button archetype")]
    public bool m_switch = false;
    bool m_switchValue = false;
    [Tooltip("Prevents the button from being interacted with again for this many seconds. " +
        "ideally should be longer than any animations associated with it")]
    public float m_interactCooldown = 2f;
    bool m_canInteract = true;
    IEnumerator interactCooldown()
    {
        yield return new WaitForSeconds(m_interactCooldown);
        m_canInteract = true;

        m_canHighlight = true;
        if (m_interactionCount >= m_maxInteractions) {
            m_canHighlight = !m_disableHighlightOnMax;
        }
        if (m_disableHighlightOnInteract && m_isHighlighted) {
            OnHighlight();
        }
    }
    [Tooltip("Maximum amount of times the button can be pressed. Set to <0 to disable.")]
    public int m_maxInteractions = -1;
    int m_interactionCount = 0;
    [Tooltip("Disable highlighting when max presses has been reached")]
    public bool m_disableHighlightOnMax = false;
    [Tooltip("Disable highlighting while interacting")]
    public bool m_disableHighlightOnInteract = true;
    [Tooltip("Max amount of times the button's action can be fired. Set to <0 to disable.")]
    public int m_maxActions = -1;
    [Tooltip("Time to wait before triggering action after button has been pressed")]
    public float m_actionDelay = 0f;

    Animator m_buttonAnimator = null;    

    public UnityEvent m_action;   
    IEnumerator doForwardAction() {
        yield return new WaitForSeconds(m_actionDelay);
        m_action.Invoke();        
    }
    public UnityEvent m_reverseAction;
    IEnumerator doReverseAction()
    {
        yield return new WaitForSeconds(m_actionDelay);
        m_reverseAction.Invoke();
    }
    void doAction()
    {
        if (!m_switchValue) StartCoroutine(doForwardAction());
        else StartCoroutine(doReverseAction());
    }

    void Start()
    {
        base.Start();

        m_buttonAnimator = GetComponent<Animator>();
    }

    public override void OnPlayerInteract()
    {
        base.OnPlayerInteract();

        if (m_canInteract)
        {
            //play sound
            if(m_soundScheme != null) playSound(m_soundScheme.m_interactSound);

            m_canInteract = false;
            m_interactionCount++;
            if (m_disableHighlightOnInteract) {
                m_canHighlight = false;
                OnUnHighlight();
            }
            //check if interaction limit has been reached
            bool cooldown = true;
            if(m_maxInteractions > 0) {
                if(m_interactionCount >= m_maxInteractions) {
                    cooldown = false;
                    m_canHighlight = !m_disableHighlightOnMax;
                }
            }
            if(cooldown) StartCoroutine(interactCooldown());

            //check if action limit has been reached
            if(m_maxActions > 0) {
                if (m_interactionCount <= m_maxActions) doAction();
            }
            else doAction();

            //do button animation
            if (m_buttonAnimator != null)
            {
                if (!m_switch) m_buttonAnimator.SetTrigger("Pressed");
                else
                {
                    m_switchValue = !m_switchValue;
                    m_buttonAnimator.SetBool("Pressed", m_switchValue);
                }
            }

            //do player animation
            if (m_playerAnimator != null) m_playerAnimator.SetTrigger("Push");
        }
    }
    
    protected override void OnHighlight() {
        if (m_canHighlight) {
            base.OnHighlight();
        }
    }
    protected override void OnUnHighlight() {        
        base.OnUnHighlight();       
    }

    void Update()
    {
        //Debug
        //if(m_switch) Debug.Log("switch: " + m_buttonAnimator.GetBool("Pressed"));
    }
}
