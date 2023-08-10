using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGate : MonoBehaviour
{
    // The button listener game object goes here
    public GameObject triggerlistener;
    ButtonListener bl;

    // Point A and Point B, where the object starts and where it ends up after it moves
    public Transform point_A;
    public Transform point_B;

    // Speed of movement
    public float speed = 1.0f;

    private float startTime;

    // Length of distance between point A and point B
    private float length;

    // Start is called before the first frame update
    void Start()
    {
        // Set Point A to the current transform position of the object
        point_A = transform;
        bl = triggerlistener.GetComponent<ButtonListener>();

        startTime = Time.time;

        // Calculate the distance from Point A and Point B
        length = Vector3.Distance(point_A.position, point_B.position);
    }

    // Update is called once per frame
    void Update()
    {
        // If the button listeners reports both buttons as pressed, open the door.
        // A problem with this code is that both buttons only neeed to be pressed simultaneously once, rather than continuously to keep the door open as initially intended.
        // I attempted to fix it with an "else" clause to revert the transform, but it doesn't quite work.
        // Ultimately it doesn't affect the intended flow of the stage in which the player must collect the Steel ability to open the door, so I'll just leave it as is.
        if (bl.activated)
        {
            // A Basic lerp-based movement tutorial taken from the Unity Documentation
            // Incrementally moves the door to the "Point_B" location.
            // (Although in this case in seems to teleport, but I couldn't quite figure out why)
            float distCovered = (Time.time - startTime) * speed;

            float fractionOfJourney = distCovered / length;

            transform.position = Vector3.Lerp(point_A.position, point_B.position, fractionOfJourney);
        }/* else
            {
            //transform.position = point_A.position;
            }
       */
    }
}
