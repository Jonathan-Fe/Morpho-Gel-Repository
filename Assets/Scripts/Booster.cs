using System.Collections;
using System.Collections.Generic;
using Unity.Collections.LowLevel.Unsafe;
using UnityEngine;

public class Booster : MonoBehaviour
{
    public GameObject booster;
    public GameObject player;

    public float boostSpeed = -500f;
    public float vertSpeed = 5f;

    public bool activated = false;
    public bool touchingPlayer = false;
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
        if (activated)
        {
            booster.GetComponent<Renderer>().material = activatedMat;
        }
        else
        {
            booster.GetComponent<Renderer>().material = inactiveMat;
        }
    }

    private void FixedUpdate()
    {
        if (activated && touchingPlayer)
        {
            player.GetComponent<Rigidbody>().AddForce(boostSpeed * Time.deltaTime, vertSpeed * Time.deltaTime, 0, ForceMode.Impulse);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (activated && collision.collider.tag == "Player")
        {
            Debug.Log("Player Touched Booster!");
            touchingPlayer = true;
            pl.launched = true;
            //collision.collider.attachedRigidbody.AddForce(boostSpeed * Time.deltaTime, 0, 0);
            //collision.collider.attachedRigidbody.AddForce(boostSpeed, 0, 0, ForceMode.Impulse);
            //collision.collider.attachedRigidbody.velocity = new Vector3(boostSpeed, 0, 0);
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.collider.tag == "Player")
        {
            touchingPlayer = false;
        }
    }
}
