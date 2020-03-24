using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpiderSpawn : MonoBehaviour
{

    public GameObject Player;
    public Vector3 SpawnPos;
    public GameObject SpawnItem;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject == Player)
        {
            Instantiate(SpawnItem, SpawnPos, Quaternion.identity);
        }
        
    }
}
