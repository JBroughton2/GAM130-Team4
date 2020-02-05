using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class SwitchTest : MonoBehaviour
{
    public GameObject light;

    public void switchLight() 
    {
        light.SetActive(true);
    }
}
