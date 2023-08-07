//using System.Collections;
//using System.Collections.Generic;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class PlayerControls : MonoBehaviour
{
    public Rigidbody rb;
    public GameObject player;
    Player_Collision ps;
    public Transform spawnPoint;
    public Camera cam;

    //Steel Transformation Ability  - Steel Balls
    public GameObject steelBall;
    private Queue<GameObject> _Balls = new Queue<GameObject>();
    private int _maxBalls = 3;

    //Wood Transformation - Wooden Platforms
    public GameObject woodPlat;
    private Queue<GameObject> _Platforms = new Queue<GameObject>();
    private int _maxPlatforms = 3;

    //Plasma Transformation - Plasma Shot
    public GameObject plasmaShot;
    public float shotSpeed = 1000f;
    public float fireRate = 2f;
    public float NextFire;
    private Vector3 _still = new Vector3(0, 0, 0);

    public float moveSpeed;
    public float jumpForce;

    public bool grounded;
    public bool launched = false;

    private void Start()
    {
        ps = player.GetComponent<Player_Collision>();
        Debug.Log(ps.playerState);
    }

    // Update is called once per frame
    void Update()
    {
        if (!launched)
        {

            Vector3 forward = cam.transform.forward;
            Vector3 right = cam.transform.right;

            //Debug.Log("Forward: " + forward);
            //Debug.Log("Right: " + right);

            float playerVerticalInput = Input.GetAxis("Vertical") * moveSpeed;
            float playerHorizontalInput = Input.GetAxis("Horizontal") * moveSpeed;

            Vector3 forwardRelative = playerVerticalInput * forward;
            Vector3 rightRelative = playerHorizontalInput * right;
            Vector3 cameraRelativeMovement = (forwardRelative + rightRelative);

            //t schrb.velocity = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, rb.velocity.y, Input.GetAxis("Vertical") * moveSpeed);
            rb.velocity = new Vector3(cameraRelativeMovement.x, rb.velocity.y, cameraRelativeMovement.z);

            //rb.velocity = cameraRelativeMovement;

            Vector3 movement = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            if (movement != _still)
            {
                transform.rotation = Quaternion.LookRotation(movement);
            }
        }

        if (Input.GetKeyDown(KeyCode.Space) && grounded)
        {
            Debug.Log("Jump is executing...");
            rb.velocity = new Vector3(rb.velocity.x, jumpForce, rb.velocity.z);
            Debug.Log("Jump is done executing.");
        }

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
                    GameObject steelB = Instantiate(steelBall, new Vector3(transform.position.x, transform.position.y, transform.position.z + 1.5f), transform.rotation);
                    steelB.name = (_Balls.Count).ToString();
                    Debug.Log("Steel Ball # " + steelB.name);
                    _Balls.Enqueue(steelB);
                    Debug.Log("Special Action performed!");
                    Debug.Log("Steel Ball Count: " + _Balls.Count);
                    if (_Balls.Count > _maxBalls)
                    {
                        GameObject temp = _Balls.Dequeue();
                        Destroy(temp);
                        Debug.Log("Destroying Excess Steel Balls...");
                    }
                    break;

                case "Wood":
                    GameObject wood = Instantiate(woodPlat, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
                    wood.name = (_Platforms.Count).ToString();
                    Debug.Log("Wood  Platform # " + wood.name);
                    _Platforms.Enqueue(wood);
                    Debug.Log("Special Action performed!");
                    Debug.Log("Platform Count: " + _Platforms.Count);
                    if (_Platforms.Count > _maxPlatforms)
                    {
                        GameObject temp = _Platforms.Dequeue();
                        Destroy(temp);
                        Debug.Log("Destroying Excess Platforms...");
                    }
                    break;

                case "Plasma":
                    NextFire = Time.time + fireRate;
                    Shoot();
                    Debug.Log("Special Action performed!");
                    break;

                default:
                    Debug.Log("Special Action not performed (?)");
                    break;
            }
        }

        // This is for debugging
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

    public void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Panel" || collision.gameObject.tag == "Metal")
        {
            grounded = true;
            launched = false;
            Debug.Log("Player is grounded");
        }
    }

    public void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.tag == "Ground" || collision.gameObject.tag == "Panel" || collision.gameObject.tag == "Metal")
        {
            grounded = false;
            Debug.Log("Player is no longer grounded");
        }
    }

    void Shoot()
    {
        GameObject shot = Instantiate(plasmaShot, spawnPoint.position, spawnPoint.rotation);
        Rigidbody rb = shot.GetComponent<Rigidbody>();
        Physics.IgnoreCollision(shot.GetComponent<Collider>(), GetComponent<Collider>());
        Vector3 direction = spawnPoint.position - transform.position;
        Debug.Log("Direction: " + direction);
        rb.velocity = new Vector3(Mathf.Clamp(direction.x * 30, -30, 30), 0, Mathf.Clamp(direction.z * 30, -30, 30));
    }
}
