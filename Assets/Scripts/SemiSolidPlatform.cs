//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class SemiSolidPlatform : MonoBehaviour
{
    public GameObject player;
    Rigidbody rb;
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
