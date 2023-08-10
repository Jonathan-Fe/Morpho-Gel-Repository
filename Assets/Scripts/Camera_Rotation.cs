//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{
    // The pivot object that the Camera rotates around
    public GameObject pivot;

    // Update is called once per frame
    void Update()
    {
        // When the player presses left, rotate the camera leftward around the pivot
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, 40 * Time.deltaTime);
        }

        // When the player presses right, rotate the camera rightward around the pivot
        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, -40 * Time.deltaTime);
        }
    }
}
