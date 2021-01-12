using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParallaxEffect : MonoBehaviour
{
    private Vector2 startPos;
    public GameObject cam;
    public float parallaxMultiplier;
    // Start is called before the first frame update
    void Start()
    {
        startPos = transform.position;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        float temp = cam.transform.position.x * (1 - parallaxMultiplier);
       
        float distX = cam.transform.position.x * parallaxMultiplier;
        float distY = cam.transform.position.y * parallaxMultiplier;

        transform.position = new Vector2(startPos.x + distX, startPos.y + distY);
    }
}
