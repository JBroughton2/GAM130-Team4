using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    Outline m_outline = null;
    public InteractableSoundScheme m_soundScheme = null;
    AudioSource m_sfxSource = null;
    public float m_soundQueueTime = 0.2f;
    bool m_soundQueued = false;
    protected void playSound(AudioClip sound) {
        if (m_soundScheme != null && !m_soundQueued) {
            m_sfxSource.PlayOneShot(sound);
            StartCoroutine(queueSound());
        }
    }
    IEnumerator queueSound() {
        m_soundQueued = true;
        yield return new WaitForSeconds(m_soundQueueTime);
        m_soundQueued = false;
    }

    //player controller
    protected static Animator m_playerAnimator = null;
    public static void setPlayerAnimator(Animator animator) { m_playerAnimator = animator; }

    // Start is called before the first frame update
    protected void Start()
    {
        m_outline = GetComponent<Outline>();
        if (m_outline != null) m_outline.enabled = false;

        m_sfxSource = GetComponent<AudioSource>();
        if (m_sfxSource == null && m_soundScheme != null)
            m_sfxSource = gameObject.AddComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    protected bool m_isHighlighted = false;
    protected bool m_canHighlight = true;
    public void OnPlayerHighlight()    
    {
        m_isHighlighted = true;
        if(m_canHighlight && m_soundScheme != null) playSound(m_soundScheme.m_highlightSound);
        OnHighlight();
    }
    protected virtual void OnHighlight() {
        if (m_outline != null) m_outline.enabled = true;        
    }

    public void OnPlayerUnHighlight()
    {
        m_isHighlighted = false;
        if(m_canHighlight && m_soundScheme != null) playSound(m_soundScheme.m_unHighlightSound);
        OnUnHighlight();
    }
    protected virtual void OnUnHighlight() {        
        if (m_outline != null) m_outline.enabled = false;        
    }

    public virtual void OnPlayerInteract()
    {
        
    }
}
