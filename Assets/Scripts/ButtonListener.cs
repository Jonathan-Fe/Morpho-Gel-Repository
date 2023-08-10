using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonListener : MonoBehaviour
{
    // The Button objects to listen to
    public GameObject button_A;
    public GameObject button_B;

    ButtonGeneric ba;
    ButtonGeneric bb;

    // Boolean - if both buttons are true, this value will be true, else it will be false
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
        // if both buttons are true, activated boolean will be true, else it will be false
        if (ba.pressed && bb.pressed)
        {
            activated = true;
        }
        else
        {
            activated = false;
        }
    }
}
