using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchLight : MonoBehaviour
{
    public GameObject unlitModel;
    public GameObject litModel;
    private GameObject currModel;
    public bool torchLightOn;

    // Start is called before the first frame update
    void Start()
    {
        // Create a Torch Object at the location of this (empty) object
        currModel = Instantiate(unlitModel, transform.position, transform.rotation) as GameObject;
        currModel.transform.parent = transform;
    }

    public void ChangeModel()
    {
        GameObject newModel = Instantiate(litModel, transform.position, transform.rotation) as GameObject;
        Destroy(currModel);
        newModel.transform.parent = transform;
        currModel = newModel;
        torchLightOn = true;
    }
}
