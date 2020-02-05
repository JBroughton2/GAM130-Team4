using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    protected static Vector3 s_curSpawnPoint = Vector3.zero;    
    
    private void OnTriggerEnter(Collider other) {
        if(other.tag == "Player") {
            GameManager.s_playerCharacterController.Teleport(s_curSpawnPoint);
        }        
    }
}
