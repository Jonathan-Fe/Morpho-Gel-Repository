using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonBridge : MonoBehaviour
{
    // Reference to the GameObject to trigger
    public GameObject bridge;

    // If Button is being hit, activate the bridge
    private void OnCollisionEnter(Collision collision)
    {
        bridge.SetActive(true);
    }

    // If Button is no longer being hit, deactivate the bridge
    private void OnCollisionExit(Collision collision)
    {
        bridge.SetActive(false);
    }

    // This code results in unintended behavior where the button can stay triggered when an object ontop of it despawns without "exiting"
    // Also, if the player runs onto a button and leaves, the button will untrigger even if there is a steel ball ontop. I attempted to fix this with OnCollisionStay,
    //  which did not quite work how I wanted, so I decided to leave it as is.
    //  Ultimately this bug is not hugely detrimental or obstructive to the gameplay experience. 
}
