using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrigger : MonoBehaviour
{
    // The Game Object to activate
    public GameObject activatedObject;

    // Boolean that checks if a metal object is in range
    public bool metalInRange = false;

    Booster bs;

    // Start is called before the first frame update
    void Start()
    {
        bs = activatedObject.GetComponent<Booster>();
    }

    // Swaps the activated state of the Booster object depending on wether or not a metal object is in the trigger
    void activationSwap()
    {
        // If a metal object is in range, activate the Booster
        // If not deactivate it.
        // (This may have a similar bug to the buttons as they also use CollisionEnter and Exit, so the deactivation may not occur)
        if (metalInRange)
        {
            bs.activated = true;
        }
        else
        {
            bs.activated = false;
        }
    }

    // When a metal object leaves the trigger area, set metal in range to false and deactivate the Booster
    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Metal")
        {
            Debug.Log("Metal is not in Range!");
            metalInRange = false;
            activationSwap();
        }
    }

    // When a metal object enters the trigger area, set metal in range to true and activate the Booster
    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Metal")
        {
            Debug.Log("Metal is in Range!");
            metalInRange = true;
            activationSwap();
        }
    }
}
