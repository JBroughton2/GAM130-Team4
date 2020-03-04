using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;

[CustomEditor(typeof(JornalData))]
public class JornalDataEditor : Editor  
{
    bool showText = false;
    bool showDebug = false;

    public override void OnInspectorGUI()
    {
        Debug();

        JornalData myTarget = (JornalData)target;

        myTarget.logTitle = EditorGUILayout.TextField("Log Title", myTarget.logTitle);
       

        showText = EditorGUILayout.Foldout(showText, "Jornal Text");

        if (showText)
            myTarget.text = GUILayout.TextArea(myTarget.text);
    }

    private void Debug()
    {
        showDebug = EditorGUILayout.Foldout(showDebug, "Debug");

        if (showDebug)
            base.OnInspectorGUI();
    }
}
