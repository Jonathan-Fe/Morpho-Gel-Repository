using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGeneric : MonoBehaviour
{
    // If Button is pressed, set "pressed" boolean to true, otherwise set it to false
    public bool pressed = false;

    // The buttons will only be triggered if the player or steel balls walks over them, wood platforms do not count
    private void OnCollisionEnter(Collision collision)
    {
        // If the colliding object is a player or steel ball, trigger the button
        if (collision.collider.tag == "Player" || collision.collider.tag == "Metal")
        {
            Debug.Log("Button is pressed!");
            pressed = true;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        // If the colliding object that triggered the button leaves the button, then deactivate the button
        if (collision.collider.tag == "Player" || collision.collider.tag == "Metal")
        {
            Debug.Log("Button is no longer pressed!");
            pressed = false;
        }
    }
}
