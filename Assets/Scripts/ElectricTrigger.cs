using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElectricTrigger : MonoBehaviour
{
    public GameObject activatedObject;
    public bool metalInRange = false;
    Booster bs;

    // Start is called before the first frame update
    void Start()
    {
        bs = activatedObject.GetComponent<Booster>();
    }

    void activationSwap()
    {
        if (metalInRange)
        {
            bs.activated = true;
        }
        else
        {
            bs.activated = false;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.tag == "Metal")
        {
            Debug.Log("Metal is not in Range!");
            metalInRange = false;
            activationSwap();
        }
    }

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
