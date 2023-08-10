using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Booster : MonoBehaviour
{
    // The booster Game Object
    public GameObject booster;

    // The Game Object that holds the active Dash Panel Texture 
    public GameObject dashTexture;

    // The player game object (Used to impact the player's velocity)
    public GameObject player;

    // The horizontal and vertical launch speed
    public float boostSpeed = -500f;
    public float vertSpeed = 5f;

    // Boolean - Checks if Booster is activated
    public bool activated = false;

    // Boolean - Check if you are currently touching the player
    public bool touchingPlayer = false;

    // The materials for both the Booster's activated and inactivated states
    public Material activatedMat;
    public Material inactiveMat;

    PlayerControls pl;

    // Start is called before the first frame update
    void Start()
    {
        pl = player.GetComponent<PlayerControls>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the Booster is activated, turn the booster object red and activate the dash panel texture object
        if (activated)
        {
            booster.GetComponent<Renderer>().material = activatedMat;
            dashTexture.SetActive(true);
        }
        else
        {
            // Otherwise, if the Booster is inactive, deactivate the dash panel texture, and turn the panel gray
            booster.GetComponent<Renderer>().material = inactiveMat;
            dashTexture.SetActive(false);
        }
    }

    // Fixed Update is used for better physics calculations
    private void FixedUpdate()
    {
        // If the booster is Activated and while the panel is touching the player, add the boostSpeed and vertSpeed forces to the player
        if (activated && touchingPlayer)
        {
            player.GetComponent<Rigidbody>().AddForce(boostSpeed * Time.deltaTime, vertSpeed * Time.deltaTime, 0, ForceMode.Impulse);
        }
    }
    // On Collision with the player, set touchingPlayer to true and set the player into a launched state
    private void OnCollisionEnter(Collision collision)
    {
        if (activated && collision.collider.tag == "Player")
        {
            Debug.Log("Player Touched Booster!");
            touchingPlayer = true;
            pl.launched = true;
        }
    }

    // When the player is no longer touching the panel, set touchingPlayer to false
    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            touchingPlayer = false;
        }
    }
}
