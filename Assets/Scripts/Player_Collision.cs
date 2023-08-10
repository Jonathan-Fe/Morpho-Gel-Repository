//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Collision : MonoBehaviour
{
    // Player Game Object
    public GameObject player;

    // The Pick Up Radius Object
    public GameObject pickUp;
    PickUpRadius pr;
    // The player's current transformation state
    public string playerState = "Slime";

    // The materials linked to eat transformation
    public Material slimeMat;
    public Material steelMat;
    public Material woodMat;
    public Material plasmaMat;

    // boolean of wether or not the player currently holds the key
    public bool hasKey = false;

    // Values of the "Steel" Layer and the "Default" layer
    int ignoreWaterLayer;
    int defaultLayer;

    private void Start()
    {
        pr = pickUp.GetComponent<PickUpRadius>();

        // Player's default state is "Slime"
        playerState = "Slime";
        Debug.Log(playerState);

        // Set the layer variables to the appropriate values
        ignoreWaterLayer = LayerMask.NameToLayer("Steel");
        defaultLayer = LayerMask.NameToLayer("Default");
    }

    // Update is called once per frame
    void Update()
    {
        // This controls the player's appearance based on their current state
        // The player's "interactions layer" is also changed here
        // Steel is the only transformation with it's own seperate layer
        switch (playerState)
        {
            case "Slime":
                player.GetComponent<Renderer>().material = slimeMat;
                player.layer = defaultLayer;
                break;

            case "Steel":
                player.GetComponent<Renderer>().material = steelMat;
                player.layer = ignoreWaterLayer;
                break;

            case "Wood":
                player.GetComponent<Renderer>().material = woodMat;
                player.layer = defaultLayer;
                break;

            case "Plasma":
                player.GetComponent<Renderer>().material = plasmaMat;
                player.layer = defaultLayer;
                break;

            default:
                player.layer = defaultLayer;
                break;
        }
    }

    // General collision code
    private void OnCollisionEnter(Collision collision)
    {
        // If the player touches water and they are currently "Slime" or "Plasma", the player will be destroyed
        // The level will restart shortly after the player's death
       if (collision.collider.tag == "Water" && playerState == "Slime" || collision.collider.tag == "Water" && playerState == "Plasma")
        {
            Debug.Log("Player touched water!");
            FindObjectOfType<GameManager>().RestartOnDeath();
            Destroy(gameObject);
        }

       // If the player is currently "Plasma", wood objects will be destroyed on contact
       if (collision.collider.tag == "Wood" && playerState == "Plasma")
        {
            Debug.Log("Plasma Burns Wood!");
            Destroy(collision.gameObject);
        }

       // If the player touches a transformation panel, update the player's state accordingly
       if (collision.collider.tag == "Panel")
        {
            Debug.Log("Player Touched a Panel...");
            playerState = collision.gameObject.GetComponent<Transform_Player>().transformation;
            Debug.Log("Player is now " + playerState + "!");
        }

       // If the player touches a door, and is holding a key, complete the level and return to level select
        if (collision.collider.tag == "Door" && pr.hasKey)
        {
            Debug.Log("Player Touched Door while holding a key!");
            SceneManager.LoadScene("Level_Select");

        }

        // If the player touches a "Death"-tagged object (i.e a Death Plane), they will be destroyed
        // The level will restart shortly after the player's death
        if (collision.collider.tag == "Death")
        {
            Debug.Log("Player Touched a Death Plane...");
            FindObjectOfType<GameManager>().RestartOnDeath();
            Destroy(gameObject);
        }
    }
}
