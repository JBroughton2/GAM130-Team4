using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LogicGate : MonoBehaviour
{
    public UnityEvent m_action;
    public UnityEvent m_reverseAction;

    bool m_isTriggered = false;

    public int m_numTriggers;
    bool[] m_triggers;

    public enum type
    {
        AND,
        OR
    }
    public type m_type = type.AND;

    bool m_nextValue = true;
    public void setNextValue(bool value)
    {
        m_nextValue = value;
        Debug.Log("next value " + value);
    }

    void Start()
    {
        m_triggers = new bool[m_numTriggers];
        for(int i = 0; i < m_triggers.Length; i++)
        {
            m_triggers[i] = false;
        }
    }
    public void setTrigger(int index)
    {
        if(index <= m_triggers.Length && index >= 0)
        {
            m_triggers[index] = m_nextValue;

            bool wasTriggered = m_isTriggered;
            m_isTriggered = m_type == type.AND;
            bool found = false;            
            for(int i = 0; i < m_triggers.Length && !found; i++)
            {
                if (m_type == type.OR && m_triggers[i])
                {
                    found = true;
                    m_isTriggered = true;
                }
                else if (m_type == type.AND && !m_triggers[i])
                {
                    found = true;
                    m_isTriggered = false;
                }
            }

            if (m_isTriggered && !wasTriggered)
            {
                m_action.Invoke();
            }
            else if(!m_isTriggered && wasTriggered)
            {
                m_reverseAction.Invoke();
            }
        }
        else
        {
            Debug.LogError("A logic gate is trying to access a trigger that doesn't exist.");
        }
    }
}
