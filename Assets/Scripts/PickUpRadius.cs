//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class PickUpRadius : MonoBehaviour
{
    // Player Game Object
    public GameObject player;
    // The SpawnPoint Game Object
    public GameObject spawnPoint;

    // The Key Game Object
    GameObject key;

    // References to the player Collision and Control scripts
    Player_Collision ps;
    PlayerControls pc;

    // Checks if the player is currently able pick up the key
    private bool canPickUp = false;

    // Checks if the player is currently holding the key
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

            // If Player is no longer slime while holding the key, drop the key at the spawn point
            if (ps.playerState != "Slime")
            {
                key.transform.parent = null;
                key.transform.position = spawnPoint.transform.position;
                hasKey = false;
            }
        }
        // if the key can be picked up and the player is currently slime, then the player can press shift to pick up the key object
        if (Input.GetKeyDown(KeyCode.LeftShift) && canPickUp && ps.playerState == "Slime")
        {
            // Make the key a child of the player
            key.transform.parent = transform;
            key.transform.localPosition = new Vector3(0, 0, 0);

            // The player has the key, so set the haskey variable to true
            hasKey = true;

            // can pick up is false because the player is currently holding the key
            canPickUp = false;
            Debug.Log("Picked up key!");
        }

    }

    // This is the invisible trigger hitbox around the player checking for the key's existence
    private void OnTriggerEnter(Collider collision)
    {
        // If a game object "key" is found in range...
        if (collision.tag == "Key")
        {
            Debug.Log("Key is within Radius!");
            // ... and the player is a slime and noty currently holding the key...
            if (ps.playerState == "Slime" && hasKey == false)
            {
                Debug.Log("The Key can be picked up!");

                // ... set canPickUp to true
                canPickUp = true;
                key = collision.gameObject;
            }
        }
    }

    // If the key leaves the pick up radius, set canPickUp to false
    private void OnTriggerExit(Collider collision)
    {
        if (collision.tag == "Key")
        {
            Debug.Log("The Key is out of range");
            canPickUp = false;
        }
    }
}
