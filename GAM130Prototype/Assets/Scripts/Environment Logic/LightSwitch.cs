using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitch : MonoBehaviour
{
    public Light[] m_lights;
    [Tooltip("Switch all lights on/off at startup")]
    public bool m_startOn = false;
    [Tooltip("Don't affect lights on at startup")]
    public bool m_startCustom = true;
    
    public void switchOn(bool on = true)
    {
        for(int i = 0; i < m_lights.Length; i++)
        {
            m_lights[i].enabled = on;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        if (!m_startCustom) switchOn(m_startOn);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
