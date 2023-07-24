//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotation : MonoBehaviour
{
    public GameObject pivot;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, 40 * Time.deltaTime);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.RotateAround(pivot.transform.position, Vector3.up, -40 * Time.deltaTime);
        }
        //transform.RotateAround(pivot.transform.position, Vector3.up, 20 * Time.deltaTime);
    }
}
