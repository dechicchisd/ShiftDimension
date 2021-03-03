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
    private bool isTurnedR = false;
    public Animator animazione;

    // Update is called once per frame
    protected virtual void Update()
    {
        if(isTurnedR == false)
        {
            alien.transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        else if (isTurnedR == true)
        {
            alien.transform.Translate(walkingSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        if ((alien.position.x < leftBound.position.x) && !isTurnedR)
        {
            transform.Rotate(0, 180f, 0);
            isTurnedR = true;
        }

        else if ((alien.position.x > rightBound.position.x) && isTurnedR)
        {
            transform.Rotate(0, 180f, 0);
            isTurnedR = false;
        }
    }

    public virtual void Dies()
    {
        Destroy(this.gameObject);
    }
}
