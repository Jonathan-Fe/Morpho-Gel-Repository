using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScrollTexture : MonoBehaviour
{
    // Horizontal Scroll Speed
    public float scrollX = 0.5f;

    // Vertical Scroll Speed
    public float scrollY = 0.5f;

    // Update is called once per frame
    void Update()
    {
        // Continually offset the texture by the Scroll Speed each frame
        float OffsetX = Time.time * scrollX;
        float OffsetY = Time.time * scrollY;
        GetComponent<Renderer>().material.mainTextureOffset = new Vector2(OffsetX, OffsetY);
    }
}
