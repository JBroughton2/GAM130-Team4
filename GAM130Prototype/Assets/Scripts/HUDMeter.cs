using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
 This class is a generic UI feature that works like a health bar. We currently plan to use it for:
 -thirst meter
 -truck fuel levels

 As with the StoryPopup class, make a prefab for this + update description when done.
     */

public class HUDMeter : MonoBehaviour {
    //The outside/background frame of the meter. 
    //Changes width along with m_maxValue (referred to as width even if height)
    public Image m_frame;
    //Inside/foreground bar, representing current value.
    //Changes width along with m_curValue
    public Image m_bar;
    //Internal distance bar sits from edge of frame
    public float m_margin = 1f;

    //whether the meter is vertically or horizontally aligned
    public bool m_vertical = false;
    //Stores the max width the meter began at, so it can be recalculated.
    float m_startWidth = 0f;

    public float m_maxValue = 100f;
    public float m_minValue = 0f;
    public float m_startValue = -1f;
    float m_curValue;

    //resizes the frame to current max value
    void calcFrame() {

    }
    //resizes the bar to current value
    void calcBar() {

    }

    //sets max value  
    public void setMaxValue(float value) {

    }
    //sets current value 
    public void setValue(float value) {

    }    
    //add to max value
    public void addMaxValue(float value) {

    }
    //add to current value
    public void addValue(float value) {
        //add
        //clamp
        calcBar();
    }


    // Start is called before the first frame update
    void Start()
    {
        //store starting width
        m_startWidth = (m_vertical) ? m_frame.rectTransform.rect.height : m_frame.rectTransform.rect.width;

        //clamp starting values
        if (m_minValue < 0f) m_minValue = 0f;
        if (m_maxValue <= m_minValue) m_maxValue = m_minValue + 1f;
        m_curValue = (m_startValue >= m_minValue && m_startValue <= m_maxValue) ? m_startValue : m_maxValue;
    }

    //Optional extras//

    //interpolate the bar width so that it animates smoothly when changing value
    
    //add a function to gradually change the current value, as if you took a healing 
    //potion that healed over time or were taking poison damage.
}
