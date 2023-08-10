//using System.Collections;
//using System.Collections.Generic;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    // The player's rigidbody component
    public Rigidbody rb;

    // The player's game objecy
    public GameObject player;

    Player_Collision ps;

    // A spawn point places in front of the player to spawn some objects
    public Transform spawnPoint;

    // The camera perspective used for the player's "camera relative movement"
    public Camera cam;

    // Steel Transformation Ability  - Steel Balls
    // A queue keeps track of how many Steel Balls exist
    // Only 3 steel balls can exist at a time
    public GameObject steelBall;
    private Queue<GameObject> _Balls = new Queue<GameObject>();
    private int _maxBalls = 3;

    //Wood Transformation - Wooden Platforms
    // A queue keeps track of how many Wooden Platforms exist
    // Only 3 Platforms can exist at a time
    public GameObject woodPlat;
    private Queue<GameObject> _Platforms = new Queue<GameObject>();
    private int _maxPlatforms = 3;

    //Plasma Transformation - Plasma Shot
    // Plasma shot Game Object
    public GameObject plasmaShot;
    // Firing Rate
    public float fireRate = 1f;
    // float used to track wether the player can fire another shot
    public float NextFire;

    // A vector that represents 0 movement
    private Vector3 _still = new Vector3(0, 0, 0);

    // Player Movement Speed
    public float moveSpeed;
    // Player Jump Height
    public float jumpForce;

    // Bool to check if the player is grounded
    //  Now Unused after changing the Ground Check system to use Raycasting instead 
    public bool grounded;

    // Sphere Collider of the player
    public SphereCollider sc;

    // The Offset for the precision groundCheck Raycast Function
    public float checkOffset = 0.1f;

    // Boolean - True if the player has been launched from a boost panel, false after touching the ground
    public bool launched = false;

    private void Start()
    {
        // Use player collision to set the player's state
        ps = player.GetComponent<Player_Collision>();
        Debug.Log(ps.playerState);
    }

    // Update is called once per frame
    void Update()
    {
        // If the player is launched, they should not be able to move
        if (!launched)
        {
            // This is the code used for Camera relative movement
            // The code includes quite a lot of complicated vector math involving the camera's current direction and transferring those to the player movement directions
            // Rather than poorly explain in my own words, i'll link the tutorial I followed to achieve this effect
            // "https://youtu.be/7kGCrq1cJew"

            Vector3 forward = cam.transform.forward;
            Vector3 right = cam.transform.right;

            //Debug.Log("Forward: " + forward);
            //Debug.Log("Right: " + right);

            float playerVerticalInput = Input.GetAxis("Vertical") * moveSpeed;
            float playerHorizontalInput = Input.GetAxis("Horizontal") * moveSpeed;

            Vector3 forwardRelative = playerVerticalInput * forward;
            Vector3 rightRelative = playerHorizontalInput * right;
            Vector3 cameraRelativeMovement = (forwardRelative + rightRelative);

            //rb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
            rb.velocity = new Vector3(cameraRelativeMovement.x, rb.velocity.y, cameraRelativeMovement.z);

            //rb.velocity = cameraRelativeMovement;

            // This controls the player's "facing" direction
            // When the player's moving, the player should rotate to face the direction of movement
            // This does not function in tandem with Camera relative movement,
            //  the player will face globally "upwards"  when up is pressed regardless of where "up" is in relation to the camera,
            //  but works from the Camera's default perspective
            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (movement != _still)
            {
                transform.rotation = Quaternion.LookRotation(movement);
            }
        }

        // When the player presses space, and there is ground underneath them, give the player vertical force
        if (Input.GetKeyDown(KeyCode.Space) && GroundCheck())
        {
            Debug.Log("Jump is executing...");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            grounded = false;
            Debug.Log("Jump is done executing.");
        }

        // This input handles all of the player's transformation actions
        if (Input.GetKeyDown(KeyCode.LeftShift))
        {
            switch (ps.playerState)
            {
                case "Slime":
                    // The "pick-up items" programming was more complicated that I initiallly thought
                    // So this is handled in it's own "PickUpRadius" Script
                    Debug.Log("Special Action performed!");
                    break;

                case "Steel":
                    // Spawn a Steel Ball at the specified location
                    GameObject steelB = Instantiate(steelBall, new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z), transform.rotation);
                    // Name the steel ball after it's index in the queue
                    steelB.name = (_Balls.Count).ToString();
                    Debug.Log("Steel Ball # " + steelB.name);
                    // Place the Steel Ball into the Ball queue
                    _Balls.Enqueue(steelB);
                    Debug.Log("Special Action performed!");
                    Debug.Log("Steel Ball Count: " + _Balls.Count);

                    // If the amount of Balls is over 3, destroy the first ball in the queue
                    if (_Balls.Count > _maxBalls)
                    {
                        GameObject temp = _Balls.Dequeue();
                        Destroy(temp);
                        Debug.Log("Destroying Excess Steel Balls...");
                    }
                    break;

                case "Wood":
                    // Spawn a Wooden Platform at the desired location
                    GameObject wood = Instantiate(woodPlat, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    // Name the Wooden Platform after it's index in the queue
                    wood.name = (_Platforms.Count).ToString();
                    Debug.Log("Wood  Platform # " + wood.name);
                    // Place the Wooden Platform in the Platform queue
                    _Platforms.Enqueue(wood);
                    Debug.Log("Special Action performed!");
                    Debug.Log("Platform Count: " + _Platforms.Count);

                    // If the amount of Platforms is over 3, destroy the first ball in the queue
                    if (_Platforms.Count > _maxPlatforms)
                    {
                        GameObject temp = _Platforms.Dequeue();
                        Destroy(temp);
                        Debug.Log("Destroying Excess Platforms...");
                    }
                    break;

                case "Plasma":
                    // If enough time has passed (fire rate interval), then the player may fire again
                    if (Time.time > NextFire)
                    {
                        // Start the cooldown until the next fire is allowed
                        NextFire = Time.time + fireRate;

                        // The function to shoot the Plasma ball
                        Shoot();
                    }
                    Debug.Log("Special Action performed!");
                    break;

                default:
                    Debug.Log("Special Action not performed (?) [This shouldn't ever happen]");
                    break;
            }
        }

        // This is for debugging
        // Button Codes to transfrom player state at will
        // 0 = Slime
        // 1 = Steel
        // 2 = Wood
        // 3 = Plasma
        if (Input.GetKeyDown(KeyCode.Alpha0))
        {
            Debug.Log("Player is now Slime!");
            ps.playerState = "Slime";
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            Debug.Log("Player is now Steel!");
            ps.playerState = "Steel";
        }

        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            Debug.Log("Player is now Wood!");
            ps.playerState = "Wood";
        }

        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            Debug.Log("Player is now Plasma!");
            ps.playerState = "Plasma";
        }

    }

    // This is the old ground check code
    // It became problematic once probuilder featured multiple linked "Ground" area, in qhich exiting from one to another was treated as being airborne.
    // This function was repurposed for managing the player's "launched" boolena instead
    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Panel" || collision.gameObject.tag == "Metal")
        {
            grounded = true;
            launched = false;
            Debug.Log("Player is grounded");
        }
    }

    /*

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Panel" || collision.gameObject.tag == "Metal")
        {
            grounded = false;
            Debug.Log("Player is no longer grounded");
        }
    }
    */

    // This function uses a raycats to check for an object under the playerfor a short distance
    // If an object is under the player, return true, if not return false
    bool GroundCheck()
    {
        Color rayColor;
        Debug.DrawRay(sc.bounds.center, Vector3.down * (sc.bounds.extents.y + checkOffset));
        if (Physics.Raycast(sc.bounds.center, Vector3.down, sc.bounds.extents.y + checkOffset))
        {
            rayColor = Color.green;
            return true;
        }
        else
        {
            rayColor = Color.red;
            return false;
        }
    }

    // Manages the shooting abilities of the Plasma Shot 
    void Shoot()
    {
        // Create a an Game Object for the plasma shot prefab at the spawnpoint position
        GameObject shot = Instantiate(plasmaShot, spawnPoint.position, spawnPoint.rotation);
        // Get the rigid body of the plasma shot object
        Rigidbody rbP = shot.GetComponent<Rigidbody>();
        // Make sure the plasma shot will ingore collisions with the player
        // Prevents the player from destroying their own bullets by running forward into them
        Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<Collider>());
        // Set a direction for the plasma shot from the player's position to the spawnpoint position
        Vector3 direction = spawnPoint.position - transform.position;
        Debug.Log("Direction: " + direction);
        // Fire the Plasma shot in the direction chosen, clamping it's speed into a range
        rbP.velocity = new Vector3(Mathf.Clamp(direction.x * 30, -30, 30), 0, Mathf.Clamp(direction.z * 30, -30, 30));
    }
}
