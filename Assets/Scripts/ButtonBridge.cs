using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBridge : MonoBehaviour
{
    public GameObject bridge;
    public bool buttonIsPushed;

    void activationSwap()
    {
        if (buttonIsPushed)
        {
            //bridge.active;
        }
        else
        {
            //bs.activated = false;
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        bridge.SetActive(true);
    }

    private void OnCollisionExit(Collision collision)
    {
        bridge.SetActive(false);
    }
}
