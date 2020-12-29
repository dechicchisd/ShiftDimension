using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStar : MonoBehaviour
{

    public bool isRunning = false;

    public Rigidbody2D star;
    public Rigidbody2D posizioneOriginale;
    public Vector2 initPosition;
    public float randomNum;
    public float randomPos;

    public float walkingSpeed;


    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 10000);
        randomPos = Random.Range(0, 60);
        initPosition = new Vector2(posizioneOriginale.position.x + randomPos, posizioneOriginale.position.y);
        transform.position = initPosition;
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning == false)
        {
            transform.position = initPosition;
            float x = Random.Range(-10000, 10000);
            if (x % randomNum == 0)
            {
                isRunning = true;
            }
        }
        else{
            if(star.position.y < -20)
            {
                isRunning = false;
            }
            else
            {/*
                transform.position = star.position - m_NewForce;*/
                star.transform.Translate(-walkingSpeed * Time.deltaTime, -walkingSpeed * Time.deltaTime, 0, Space.World);
            }
        }
        initPosition = new Vector2(posizioneOriginale.position.x + randomPos, posizioneOriginale.position.y);

    }

}
