using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TorchListeners : MonoBehaviour
{
    public GameObject torch_A;
    public GameObject torch_B;

    TorchLight ta;
    TorchLight tb;

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
        if (ta.torchLightOn && tb.torchLightOn)
        {
            activated = true;
        }
    }
}
