using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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
