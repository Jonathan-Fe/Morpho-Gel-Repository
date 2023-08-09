//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Plasma_Shot : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.collider.tag == "Torch")
        {
            TorchLight tl = collision.collider.transform.parent.gameObject.GetComponent<TorchLight>();
            if (tl.torchLightOn == false)
            {
                Debug.Log("Torch has been lit. This should only be called once.");
                tl.ChangeModel();
            }
        }
        Destroy(gameObject);
    }

}
