//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PickUpRadius : MonoBehaviour
{
    public GameObject player;
    public GameObject spawnPoint;
    GameObject key;
    Player_Collision ps;
    PlayerControls pc;
    private bool canPickUp = false;
    public bool hasKey = false;

    private void Start()
    {
        ps = player.GetComponent<Player_Collision>();
        pc = player.GetComponent<PlayerControls>();
        Debug.Log(ps.playerState);
    }

    private void Update()
    {
        // For Dropping the Key
        if (hasKey)
        {
            // If Player pressed Shift while holding the key, drop it
            if (Input.GetKeyDown(KeyCode.LeftShift) && hasKey)
            {
                // Remove Key as a Child of Player
                key.transform.parent = null;
                // Set Key Position to the item spawn point
                key.transform.position = spawnPoint.transform.position;
                // Set hasKey variable to false
                hasKey = false;
            }

            // If Player is no longer slime while holding the key, drop the key
            if (ps.playerState != "Slime")
            {
                key.transform.parent = null;
                key.transform.position = spawnPoint.transform.position;
                hasKey = false;
            }
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && canPickUp && ps.playerState == "Slime")
        {
            key.transform.parent = transform;
            key.transform.localPosition = new Vector3(0, 0, 0);
            hasKey = true;
            canPickUp = false;
            Debug.Log("Picked up key!");
        }

    }

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.tag == "Key")
        {
            Debug.Log("Key is within Radius!");
            if (ps.playerState == "Slime" && hasKey == false)
            {
                Debug.Log("The Key can be picked up!");
                canPickUp = true;
                key = collision.gameObject;
            }
        }
    }

    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Key")
        {
            Debug.Log("The Key is out of range");
            canPickUp = false;
        }
    }
}
