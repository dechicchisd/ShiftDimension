using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformController : MonoBehaviour
{
    public Transform leftBound, rightBound;
    public float speed;
    Vector2 nextPos;

    private void Start()
    {
        transform.position = leftBound.position;
        nextPos = rightBound.position;
    }
    // Update is called once per frame
    void Update()
    {

        if(transform.position.x <= leftBound.position.x)
        {
            nextPos.x = rightBound.position.x;
        }

        if(transform.position.x >= rightBound.position.x)
        {
            nextPos.x = leftBound.position.x;
        }

        transform.position = Vector2.MoveTowards(transform.position, nextPos, speed * Time.deltaTime);
    }
}
