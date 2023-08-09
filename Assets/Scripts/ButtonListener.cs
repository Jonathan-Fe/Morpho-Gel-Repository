using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour
{
    public GameObject button_A;
    public GameObject button_B;

    ButtonGeneric ba;
    ButtonGeneric bb;

    public bool activated = false;

    // Start is called before the first frame update
    void Start()
    {
        ba = button_A.GetComponent<ButtonGeneric>();
        bb = button_B.GetComponent<ButtonGeneric>();
    }

    // Update is called once per frame
    void Update()
    {
        if (ba.pressed && bb.pressed)
        {
            activated = true;
        }
    }
}
