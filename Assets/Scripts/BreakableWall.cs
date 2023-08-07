using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreakableWall : MonoBehaviour
{
    public GameObject player;
    PlayerControls pl;
    Player_Collision ps;

    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerControls>();
        ps = player.GetComponent<Player_Collision>();
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.collider.tag == "Player" && pl.launched == true && ps.playerState == "Steel")
        {
            Destroy(gameObject);
        }
    }

}
