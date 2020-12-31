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
    private EdgeCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        col = alien.GetComponent<EdgeCollider2D>();
    }

    // Update is called once per frame
    void Update()
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
        float xground = GetComponent<Collider2D>().bounds.center.x;
        float yground = GetComponent<Collider2D>().bounds.center.y - GetComponent<Collider2D>().bounds.size.y/2;
    }

    public virtual void Dies()
    {
        Destroy(this.gameObject);
    }
}
