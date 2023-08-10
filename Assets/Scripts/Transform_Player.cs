//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Transform_Player : MonoBehaviour
{
    // The Panel Game Object (The Panel this script is attached to)
    public GameObject panel;

    // A string that determines with transformation the player will undergo on contact
    public string transformation;

    // The materials for each transformation
    public Material slime;
    public Material steel;
    public Material wood;
    public Material plasma;

    // Start is called before the first frame update
    void Start()
    {
        // This controls the panel's appearance based on their transformation string
        switch (transformation)
        {
            case "Slime":
                panel.GetComponent<Renderer>().material = slime;
                Debug.Log("Changing Panel to Slime");
                break;

            case "Steel":
                panel.GetComponent<Renderer>().material = steel;
                break;

            case "Wood":
                panel.GetComponent<Renderer>().material = wood;
                break;

            case "Plasma":
                panel.GetComponent<Renderer>().material = plasma;
                break;

            default:
                break;
        }
    }
}
