using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// This script was initially used to change the tangibility of water before I changed my code to use layers instead
// Thus, this script is no longer used
public class Trigger_Swap : MonoBehaviour
{
    public GameObject player;
    public Collider col;
    Player_Collision ps;

    private void Start()
    {
        ps = player.GetComponent<Player_Collision>();
    }
    // Update is called once per frame
    void Update()
    {
        if (ps.playerState == "Steel")
        {
            col.isTrigger = true;
        } else
        {
            col.isTrigger = false;
        }

        if (ps.playerState == "Wood")
        {
            gameObject.tag = "Ground";
        }
        else
        {
            gameObject.tag = "Water";
        }
    }
}
