using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchListeners : MonoBehaviour
{
    // The Torch Game Objects to listen to
    public GameObject torch_A;
    public GameObject torch_B;

    TorchLight ta;
    TorchLight tb;

    // Boolean - Only true if both torches are active
    public bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        ta = torch_A.GetComponent<TorchLight>();
        tb = torch_B.GetComponent<TorchLight>();
    }

    // Update is called once per frame
    void Update()
    {
        // If the torches are both lit, set the activated boolean to true, else set it to be false
        if (ta.torchLightOn && tb.torchLightOn)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }
    }
}
