using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{

    public Rigidbody2D alien;
    private float posIniziale;
    public float offset;
    public float walkingSpeed;
    private bool isRight = false;
    private EdgeCollider2D col;

    // Start is called before the first frame update
    void Start()
    {
        posIniziale = alien.position.x;
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

        if (alien.position.x < posIniziale - offset)
            isRight = true;

        if (alien.position.x > posIniziale + offset)
            isRight = false;
    }

    public void Hurt()
    {
        Destroy(this.gameObject);
    }
}
