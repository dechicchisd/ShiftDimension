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

    // Update is called once per frame
    protected virtual void Update()
    {
        if(isRight == false)
        {
            alien.transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        else if (isRight == true)
        {
            alien.transform.Translate(walkingSpeed * Time.deltaTime, 0, 0, Space.World);
        }

        if (alien.position.x < leftBound.position.x)
        {
            isRight = true;
        }

        if (alien.position.x > rightBound.position.x)
        {
            isRight = false;
        }
    }

    public virtual void Dies()
    {
        Destroy(this.gameObject);
    }
}
