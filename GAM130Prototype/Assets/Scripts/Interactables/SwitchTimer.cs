using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchTimer : MonoBehaviour
{
    private float m_timeLeft;
    public int m_switchCount;

    void Start()
    {
        
    }

    void Update()
    {
        m_timeLeft -= Time.deltaTime;

        if(m_timeLeft <= 0 && m_switchCount < 3)
        {
            //Reset Switch Int
        }
    }
}
