using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonGeneric : MonoBehaviour
{
    public bool pressed = false;

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Button is pressed!");
        pressed = true;
    }

    private void OnCollisionExit(Collision collision)
    {
        Debug.Log("Button is no longer pressed!");
        pressed = false;
    }
}
