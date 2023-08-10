//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class SemiSolidPlatform : MonoBehaviour
{
    // The Player Game Object
    public GameObject player;

    // The Player Game Object's RigidBody
    Rigidbody rb;

    // The Platform's Collider object
    public Collider col;

    private void Start()
    {
        rb = player.GetComponent<Rigidbody>();
    }
    // Update is called once per frame
    void Update()
    {
        // Check if player exists before making the velocity check
        // This prevents error messages from popping up if the player dies.
        if (GameObject.Find("Player"))
        {
            // If the player is currently moving upwards, the platform becomes a trigger, else it remains solid
            // This enables the player to jump through the platform if the are jumping from underneath it
            if (rb.velocity.y > 0)
            {
                col.isTrigger = true;
            }
            else
            {
                col.isTrigger = false;
            }
        }
    }
}
