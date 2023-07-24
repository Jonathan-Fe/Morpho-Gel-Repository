//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player_Collision : MonoBehaviour
{
    public GameObject player;
    public GameObject pickUp;
    PickUpRadius pr;
    public string playerState = "Slime";
    public Material slimeMat;
    public Material steelMat;
    public Material woodMat;
    public Material plasmaMat;
    public bool hasKey = false;
    int ignoreWaterLayer;
    int defaultLayer;

    private void Start()
    {
        pr = pickUp.GetComponent<PickUpRadius>();
        playerState = "Slime";
        Debug.Log(playerState);
        ignoreWaterLayer = LayerMask.NameToLayer("Steel");
        defaultLayer = LayerMask.NameToLayer("Default");
    }

    // Update is called once per frame
    void Update()
    {
        // This controls the player's appearance based on their current state
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

    private void OnCollisionEnter(Collision collision)
    {
       if (collision.collider.tag == "Water" && playerState == "Slime" || collision.collider.tag == "Water" && playerState == "Plasma")
        {
            Debug.Log("Player touched water!");
            FindObjectOfType<GameManager>().RestartOnDeath();
            Destroy(gameObject);
        }

       if (collision.collider.tag == "Panel")
        {
            Debug.Log("Player Touched a Panel...");
            playerState = collision.gameObject.GetComponent<Transform_Player>().transformation;
            Debug.Log("Player is now " + playerState + "!");
        }

        if (collision.collider.tag == "Door" && pr.hasKey)
        {
            Debug.Log("Player Touched Door while holding a key!");
            SceneManager.LoadScene("Level_Select");

        }
    }
}
