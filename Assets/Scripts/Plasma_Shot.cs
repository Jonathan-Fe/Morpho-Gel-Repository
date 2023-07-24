//using System.Collections;
//using System.Collections.Generic;
using UnityEngine;

public class Plasma_Shot : MonoBehaviour
{

    private void OnCollisionEnter(Collision collision)
    {
        Destroy(gameObject);
    }
}
