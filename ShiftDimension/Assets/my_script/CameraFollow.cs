using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Vector3 offset;
    public Rigidbody2D target;
    public Rigidbody2D zero_camera;
    public Rigidbody2D zero_limite_superiore;
    public Rigidbody2D zero_limite_inferiore;
    public Rigidbody2D uno_camera;
    public float posizioneCamera;


     void start()
    {
        transform.position = new Vector3(target.position.x + offset.x, target.position.y, offset.z);
        posizioneCamera = target.position.y;
    }
    // Update is called once per frame
    void LateUpdate()
    {
        if(target != null)
        {
            if(target.position.y < zero_limite_superiore.position.y && target.position.y > zero_limite_inferiore.position.y)
            {
                if (transform.position.y != zero_camera.position.y)
                {
                    posizioneCamera = transform.position.y - 0.5f;
                }
                transform.position = new Vector3(target.position.x + offset.x, posizioneCamera + offset.y, offset.z);
            }
            else if (target.position.y <= zero_limite_inferiore.position.y)
            {
                
                if (transform.position.y > uno_camera.position.y)
                {
                    posizioneCamera = transform.position.y - 0.5f;
                }
                transform.position = new Vector3(target.position.x + offset.x, posizioneCamera, offset.z);
            }
        }
        
            

    }
}
