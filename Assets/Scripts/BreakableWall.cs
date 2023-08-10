using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    // Store the Player Game Object
    public GameObject player;

    // This done to obtain information about the player's states
    PlayerControls pl;
    Player_Collision ps;

    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerControls>();
        ps = player.GetComponent<Player_Collision>();
    }

    // If the player touches the object and the player has been both "launched" and is currently "Steel", the wall will break.
    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" && pl.launched == true && ps.playerState == "Steel")
        {
            Destroy(gameObject);
        }
    }

}
