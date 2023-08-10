using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveGateTorch : MonoBehaviour
{
    // Torch Listener GameObject goes here
    public GameObject triggerlistener;
    TorchListeners tl;

    // The point for the object to move, from Point A to Point B
    public Transform point_A;
    public Transform point_B;

    // The speed at which the object will move from Point A to Point B
    public float speed = 1.0f;

    private float startTime;

    private float length;

    // Start is called before the first frame update
    void Start()
    {
        // Set point A to current transform position
        point_A = transform;
        tl = triggerlistener.GetComponent<TorchListeners>();

        startTime = Time.time;

        // Length from Point A to Point B
        length = Vector3.Distance(point_A.position, point_B.position);
    }

    // Update is called once per frame
    void Update()
    {
        // If the torchlisteners says that both torches are lit, then move the gate
        if (tl.activated)
        {
            // A Basic lerp-based movement tutorial taken from the Unity Documentation
            // Incrementally moves the door to the "Point_B" location.
            // (Although in this case in seems to teleport, but I couldn't quite figure out why)
            float distCovered = (Time.time - startTime) * speed;

            float fractionOfJourney = distCovered / length;

            transform.position = Vector3.Lerp(point_A.position, point_B.position, fractionOfJourney);
        }
        /*
        else
        {
            transform.position = point_A.position;
        }
        */
    }
}
