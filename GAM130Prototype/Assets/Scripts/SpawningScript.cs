using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawningScript : MonoBehaviour
{

    public GameObject Player;
    public Vector3 SpawnPos;
    public GameObject SpawnItem;
    public bool itemSpawned;
    public GameObject particleSFX;
    public Vector3 SpawnPos2;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player && itemSpawned == true)
        {
            Instantiate(SpawnItem, SpawnPos, Quaternion.identity);
            Instantiate(particleSFX, SpawnPos2, Quaternion.identity);
            itemSpawned = false;
        }
    }
}