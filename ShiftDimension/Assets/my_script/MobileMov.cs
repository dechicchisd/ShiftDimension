using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;

public class MobileMov : MonoBehaviour
{
    public Rigidbody2D player;
    public Vector2 m_NewForce = new Vector2(0, 30f);
    public Animator animazione;
    public bool isActor1OnTheGround = true;
    public bool isRiight = true;
    public ForceMode2D salto;
    public float t;
    public static float altezzaCorrente;
    public BoxCollider2D playerCollider;
    private float walkingSpeed = 0.07f;
    public Joystick joystick;
    public Button jumpButton;
    private Button btn;

    // Start is called before the first frame update
    void Start()
    {
        animazione = GetComponent<Animator>();
        altezzaCorrente = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.y < altezzaCorrente)
        {
            animazione.Play("rest");
            isActor1OnTheGround = false;
        }
    
        if (joystick.Horizontal >= .2f)
        {
            walkRight();
        }
        else if (joystick.Horizontal <= -.2f)
        {
            walkLeft();
        }
        else if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")))
        {
            animazione.Play("rest");
        }
        altezzaCorrente = player.position.y;

      
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isActor1OnTheGround = true;
            animazione.Play("rest");
        }
        else if (collision.gameObject.tag == "Underground")
        {
            isActor1OnTheGround = true;
            animazione.Play("rest");
            player.AddForce(new Vector2(0, 1f), ForceMode2D.Impulse);
        }
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isActor1OnTheGround = true;
        }
        else
        {
            isActor1OnTheGround = false;
        }
    }

    public void jumpAction()
    {
        isActor1OnTheGround = false;
        if (player.velocity.y == 0)
        {
            player.velocity = Vector2.up * m_NewForce;
            if (player.position.y < altezzaCorrente)
            {
                animazione.Play("rest");
            }
            else
            {
                animazione.Play("jump");
            }
        }

    }

    private void walkRight()
    {
        if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && isActor1OnTheGround == true)
        {
            animazione.Play("walk");
        }
        //se il player è rivolto a sinistra
        if (isRiight == false)
        {
            //si gira a destra
            transform.Rotate(0, 180f, 0);
            isRiight = true;
        }
        player.transform.Translate(walkingSpeed, 0, 0);
    }

    private void walkLeft()
    {
        if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && isActor1OnTheGround == true)
        {
            animazione.Play("walk");
        }
        //se il player è rivolto a destra
        if (isRiight == true)
        {
            //si gira a sinistra
            transform.Rotate(0, 180f, 0);
            isRiight = false;
        }
        player.transform.Translate(walkingSpeed, 0, 0);
    }
}
