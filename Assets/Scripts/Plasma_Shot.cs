//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Plasma_Shot : MonoBehaviour
{
    // General collision code
    private void OnCollisionEnter(Collision collision)
    {
        // If the plasma shot collides with a torch, "light" the torch
        if (collision.collider.tag == "Torch")
        {
            TorchLight tl = collision.collider.transform.parent.gameObject.GetComponent<TorchLight>();
            if (tl.torchLightOn == false)
            {
                Debug.Log("Torch has been lit. This should only be called once.");
                tl.ChangeModel();
            }
        }

        // Upon collision with any object, destroy the Plasma Shot
        Destroy(gameObject);
    }

}
