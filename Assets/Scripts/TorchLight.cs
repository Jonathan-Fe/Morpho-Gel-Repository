using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    // Store the model for a lit and unlit torch prefab
    public GameObject unlitModel;
    public GameObject litModel;

    // keep a reference of the current model in use
    private GameObject currModel;

    // Boolean of wether or not the Torch has been lit
    public bool torchLightOn;

    // Start is called before the first frame update
    void Start()
    {
        // Create a Torch Object at the location of this (empty) object and store it as "currModel"
        currModel = Instantiate(unlitModel, transform.position, transform.rotation) as GameObject;
        currModel.transform.parent = transform;
    }

    // Function used to change the Torch's model when it is hit by a Plasma Ball
    public void ChangeModel()
    {
        // Create a temporary model to reference the new (lit) model
        GameObject newModel = Instantiate(litModel, transform.position, transform.rotation) as GameObject;

        // Destroy the current (unlit) model
        Destroy(currModel);

        // Transform this new model to the location of the correct location and store it as the currModel
        newModel.transform.parent = transform;
        currModel = newModel;

        // Switch TorchLight boolean to "true"
        torchLightOn = true;
    }
}
