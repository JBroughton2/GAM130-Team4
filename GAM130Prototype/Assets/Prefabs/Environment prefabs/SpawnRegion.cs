using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnRegion : DeathZone
{
    public Vector3 m_spawnPoint = Vector3.zero;
    private void Start() {
        if (m_spawnPoint == Vector3.zero) {
            GameObject spawnPoint = transform.Find("SpawnPoint").gameObject;
            if(spawnPoint != null) m_spawnPoint = spawnPoint.transform.position;
        }
    }
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            s_curSpawnPoint = m_spawnPoint;
            Debug.Log("ttsdfsdf");
        }
    }
}
