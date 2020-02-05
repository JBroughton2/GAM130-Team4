using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Lean.Pool;

public class ButtonTest : MonoBehaviour
{
    public GameObject m_spawnObject;
    public Vector3 m_spawnPoint = Vector3.zero;

    public void spawnObject() {
        LeanPool.Spawn(m_spawnObject, m_spawnPoint, Quaternion.identity);
    }
}
