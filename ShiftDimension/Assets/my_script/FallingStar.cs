using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FallingStar : MonoBehaviour
{

    public bool isRunning = false;

    public Rigidbody2D leftBound;
    public Rigidbody2D rightBound;
    public Rigidbody2D star;
    private Vector2 velocity;
    public Vector2 m_NewForce = new Vector2(.0000001f, .0000002f);

    public float posizioneInizio;
    public float posizioneFine;

    // Start is called before the first frame update
    void Start()
    {
        transform.position = leftBound.position;
        velocity = new Vector2(.00000001f, .00000001f);
    }

    // Update is called once per frame
    void Update()
    {
        if(isRunning == false)
        {
            float x = Random.Range(-10000, 10000);
            if (x % 537 == 0)
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
                star.MovePosition(rightBound.position + velocity * Time.fixedDeltaTime);
            }
        }
        

    }

    IEnumerator IntervalloRicaricaScena()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);



        leftBound.MovePosition(rightBound.position);
        /*player.MovePosition(nuovaPosizione);*/


        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(3f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

    }
}
