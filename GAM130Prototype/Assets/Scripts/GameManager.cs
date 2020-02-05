using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    static GameManager s_this;
    public static GameManager obj() {
        return s_this;
    }

    //'global' objects
    public static GameObject s_player;
    public static PlayerCharacterController s_playerCharacterController;

    // Start is called before the first frame update
    void Start()
    {
        if (s_this != null) {
            Destroy(gameObject);
            return;
        }
        s_this = this;

        //get global objects
        s_player = GameObject.Find("Player");
        if (s_player != null) s_playerCharacterController = s_player.GetComponent<PlayerCharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
