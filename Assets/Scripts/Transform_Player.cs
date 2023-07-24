//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

public class Transform_Player : MonoBehaviour
{
    public GameObject panel;
    public string transformation;

    public Material slime;
    public Material steel;
    public Material wood;
    public Material plasma;

    // Start is called before the first frame update
    void Start()
    {
        // This controls the player's appearance based on their current state
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
