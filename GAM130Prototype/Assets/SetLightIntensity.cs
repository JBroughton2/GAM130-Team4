using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[ExecuteInEditMode]
public class SetLightIntensity : MonoBehaviour
{
    Light[] m_lights;
    public float m_intensity = 1f;
    float m_prevIntensity = 0f;
    // Start is called before the first frame update
    void Start()
    {
        m_lights = GetComponentsInChildren<Light>();

        ApplyLighting();
    }

    [ContextMenu("Apply Lighting")]
    public void ApplyLighting()
    {
        foreach (Light i in m_lights)
        {
            i.intensity = m_intensity;
        }
    }

    //void OnGUI()
    //{
    //    //Draw things here. Same as custom inspectors, EditorGUILayout and GUILayout has most of the things you need

    //    if (GUILayout.Button("Apply Lighting"))
    //    {
    //        ApplyLighting();
    //    }
    //}

    //// Update is called once per frame
    //void Update()
    //{
    //    ApplyLighting();
    //    //Debug.Log("update");
    //}
}
