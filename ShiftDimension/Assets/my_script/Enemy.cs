using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D alien;
    private float posIniziale;
    public Rigidbody2D leftBound;
    public Rigidbody2D rightBound; 
    public float walkingSpeed;
    private bool isRight = false;
    private bool isTurnedR = false;
    private bool isTurnedL = true;
    public Animator animazione;

    // Update is called once per frame
    protected virtual void Update()
    {
        if(isRight == false)
        {
            if(isTurnedL == false)
            {
                transform.Rotate(0, 180f, 0);
                isTurnedL = true;
            }
            animazione.Play("alienWalk");
            alien.transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        else if (isRight == true)
        {
            if (isTurnedR == false)
            {
                transform.Rotate(0, 180f, 0);
                isTurnedR = true;
            }
            animazione.Play("alienWalk");
            alien.transform.Translate(walkingSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        if (alien.position.x < leftBound.position.x)
        {
            isRight = true;
            isTurnedL = false;
        }

        if (alien.position.x > rightBound.position.x)
        {
            isRight = false;
            isTurnedR = false;
        }
    }

    public virtual void Dies()
    {
        Destroy(this.gameObject);
    }
}
