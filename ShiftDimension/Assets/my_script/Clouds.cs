using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Clouds : MonoBehaviour
{

    public bool isRunning = false;

    public Rigidbody2D cloud;
    public Rigidbody2D posizioneOriginale;
    public Vector2 initPosition;
    public Vector2 initPositionCloud;
    public float randomNum;
    public float randomPos;
    public float randomPosY;

    public float walkingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 10000);
        randomPos = Random.Range(0, 100);
        randomPosY = Random.Range(-2, 2);
        initPositionCloud = new Vector2(posizioneOriginale.position.x + initPosition.x, initPosition.y);
        transform.position = initPositionCloud;
    }

    // Update is called once per frame
    void Update()
    {
        if (isRunning == false)
        {
            transform.position = initPositionCloud;
            isRunning = true;
        }
        else
        {
            if (cloud.position.x < posizioneOriginale.position.x - 50)
            {
                isRunning = false;
            }
            else
            {/*
                transform.position = star.position - m_NewForce;*/
                cloud.transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0, Space.World);
            }
        }
        initPositionCloud = new Vector2(posizioneOriginale.position.x + initPosition.x, initPosition.y);

    }
}
