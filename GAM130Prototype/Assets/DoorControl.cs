using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorControl : MonoBehaviour
{
    public Animator m_doorAnimator = null;
    public BoxCollider m_doorCollider = null;
    public float m_openCollideDelay = 0.5f;
    IEnumerator openCollider() {
        yield return new WaitForSeconds(m_openCollideDelay);
        m_doorCollider.enabled = false;
    }

    private void Start() {
        m_doorCollider.enabled = true;
    }

    public void Open() {
        m_doorAnimator.SetBool("Open", true);
        StartCoroutine(openCollider());
    }
    public void Close() {
        m_doorAnimator.SetBool("Open", false);
        m_doorCollider.enabled = true;
    }
}
