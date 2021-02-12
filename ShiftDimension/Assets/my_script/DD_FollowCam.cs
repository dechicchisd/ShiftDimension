using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DD_FollowCam : MonoBehaviour
{
    public Rigidbody2D player;
    public Vector3 offset;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void LateUpdate()
    {
        if (player != null)
        {
            transform.position = new Vector3(player.position.x, player.position.y) + offset;
        }
    }
}
