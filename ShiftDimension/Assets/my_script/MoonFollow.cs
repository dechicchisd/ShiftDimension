using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonFollow : MonoBehaviour
{
    public Vector3 offset;
    public Rigidbody2D target;
    // Update is called once per frame
    void LateUpdate()
    {
        if (target != null)
            transform.position = new Vector3(target.position.x + offset.x, offset.y, offset.z);
    }
}
