using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveGate : MonoBehaviour
{
    public GameObject triggerlistener;
    ButtonListener bl;


    public Transform point_A;
    public Transform point_B;

    public float speed = 1.0f;

    private float startTime;

    private float length;

    // Start is called before the first frame update
    void Start()
    {
        point_A = transform;
        bl = triggerlistener.GetComponent<ButtonListener>();

        startTime = Time.time;

        length = Vector3.Distance(point_A.position, point_B.position);
    }

    // Update is called once per frame
    void Update()
    {
        if (bl.activated)
        {
            float distCovered = (Time.time - startTime) * speed;

            float fractionOfJourney = distCovered / length;

            transform.position = Vector3.Lerp(point_A.position, point_B.position, fractionOfJourney);
        }
    }
}
