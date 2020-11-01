using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class comando_mov : MonoBehaviour
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


    // Start is called before the first frame update
    void Start()
    {
        animazione = GetComponent<Animator>();
        altezzaCorrente = player.position.y;
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < altezzaCorrente)
        {
            animazione.Play("rest");
            isActor1OnTheGround = false;
        }
        if (Input.GetKeyDown("space") && isActor1OnTheGround == true)
        {
            jumpAction();
        }

        else if (Input.GetKey("d"))
        {
            walkRight();
        }
        else if (Input.GetKey("a"))
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

    private void jumpAction()
    {
        isActor1OnTheGround = false;
        player.AddForce(m_NewForce, ForceMode2D.Impulse);
        if (player.position.y < altezzaCorrente)
        {
            animazione.Play("rest");
        }
        else
        {
            animazione.Play("jump");
        }

    }

    private void walkRight()
    {
        if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && isActor1OnTheGround == true)
        {
            animazione.Play("walk");
        }
        if (isRiight == false)
        {
            player.transform.Rotate(0, 180f, 0);
            isRiight = true;
        }
        player.transform.Translate(0.03f, 0, 0);
    }

    private void walkLeft()
    {
        if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && isActor1OnTheGround == true)
        {
            animazione.Play("walk");
        }
        if (isRiight == true)
        {
            player.transform.Rotate(0, 180f, 0);
            isRiight = false;
        }
        player.transform.Translate(0.03f, 0, 0);
    }
}
