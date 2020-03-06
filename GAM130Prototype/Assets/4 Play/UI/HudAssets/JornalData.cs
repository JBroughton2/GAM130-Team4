using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "JornalData", menuName = "JornalData", order = 0)]
public class JornalData : ScriptableObject
{
    public string logTitle;
    public string text;

    public void RunMePlz()
    {
        Debug.Log("Runnnn");
    }
}
