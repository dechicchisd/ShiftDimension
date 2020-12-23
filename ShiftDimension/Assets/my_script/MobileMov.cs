using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using System;
using UnityEngine.SceneManagement;
using TMPro;

public class MobileMov : MonoBehaviour
{
    [SerializeField] private LayerMask platformLayerMask;
    public Rigidbody2D player;
    public Vector2 m_NewForce = new Vector2(0, 30f);
    public Animator animazione;
    public bool isActor1OnTheGround = true;
    public bool isRiight = true;
    public ForceMode2D salto;
    public static float altezzaCorrente;
    public static float altezzaInizio;    //VARIABILE CHE MI RITORNA L'ALTEZZA CORRENTE DEL PLAYER (SI AGGIORNA OGNI FRAME)
    public static float distanzaCorrente;    //VARIABILE CHE MI RITORNA LA DISTANZA PERCORSA CORRENTE DEL PLAYER (SI AGGIORNA OGNI FRAME)
    public static float distanzaInizio;    //VARIABILE CHE MI RITORNA LA DISTANZA INIZIALEDEL LIVELLO (SI AGGIORNA OGNI FRAME
    private float walkingSpeed = 15.0f;
    public Rigidbody2D inizioLivello;
    public Joystick joystick;
    private Button btn;
    private Vector2 nuovaPosizione;
    public float collidingForce;
    public TextMeshProUGUI textCoin;
    private BoxCollider2D boxCollider;


    // Start is called before the first frame update
    void Start()
    {
        nuovaPosizione = new Vector2(inizioLivello.position.x + distanzaCorrente, altezzaCorrente + 1.1f);
        player.MovePosition(nuovaPosizione);
        animazione = GetComponent<Animator>();
        animazione.Play("rest");
        boxCollider = transform.GetComponent<BoxCollider2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded() && player.position.y < altezzaCorrente)
        {
            animazione.Play("land");
        }

        if (joystick.Horizontal >= .2f)
        {
            WalkRight();
        }
        else if (joystick.Horizontal <= -.2f)
        {
            WalkLeft();
        }
        else if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && !(animazione.GetCurrentAnimatorStateInfo(0).IsName("land"))) //SE NON VIENE PREMUTO NULLA E L'ANIMAZIONE CORRENTE NON è JUMP O LAND, FAI ANDARE L'ANIMAZIONE
        {
            animazione.Play("rest");
        }
        altezzaCorrente = player.position.y; //AGGIORNA L'ALTEZZA CORRENTE DEL PLAYER
        distanzaCorrente = player.position.x;


    }

    private void OnTriggerEnter2D(Collider2D coll) 
    {
        float numCoin = System.Single.Parse(textCoin.text) + 1;
        if(coll.tag == "Coin")
        {
            Destroy(coll.gameObject);
            textCoin.text = numCoin.ToString("0");
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)  //CHIAMATA QUANDO C'è UNA COLLISIONE TRA DUE COLLIDER
    {
        if (collision.gameObject.tag == "Ground")  //SE C'è UNA COLLISIONE CON UN OGGETTO CHE HA IL TAG GROUND, SEGNALA CHE IL PLAYER STA SUL TERRENO, E FAI PARTIRE L'ANIMAZIONE REST
        {
            isActor1OnTheGround = true;
            animazione.Play("rest");
        }
        else if (collision.gameObject.tag == "Underground") //SE C'è UNA COLLISIONE CON UN OGGETTO CHE HA IL TAG UNDERGROUND, SEGNALA CHE IL PLAYER STA SUL TERRENO, FAI PARTIRE L'ANIMAZIONE LAND E RIMANDA IL LAYER VERSO IL BASSO
        {
            isActor1OnTheGround = true;
            animazione.Play("land");
            player.AddForce(new Vector2(0, -1f), ForceMode2D.Impulse);
        }

        else if (collision.gameObject.tag == "Enemy")
        {
            if (collision.contacts[0].point.y == collision.contacts[1].point.y) //SE DUE PUNTI DI COLLISIONE CONSECUTIVI HANNO LA STESSA Y ALLORA LA COLLISIONE
                                                                                //è SULLA FACCIA SUPERIORE DEL NEMICO
            {
                player.AddForce(new Vector2(0, collidingForce), ForceMode2D.Impulse);
                Destroy(collision.gameObject);
            }

            else
            {
                Destroy(this.gameObject);
            }
        }

        
    }

    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isActor1OnTheGround = true;
        }
    }

    public void JumpAction() //FUNZIONE DI SALTO
    { 
        if(IsGrounded())
        {
            isActor1OnTheGround = false;
            player.AddForce(m_NewForce, ForceMode2D.Impulse);
            if (player.position.y < altezzaCorrente) //SE IL PLAYER STA SCENDENDO, MANDA L'ANIMAZIONE LAND, ALTRIMENTI MANDA L'ANIMAZIONE JUMP
            {
                animazione.Play("land");
            }
            else
            {
                animazione.Play("jump");
            }
        }
        

    }

    private void WalkRight() //FUNZIONE DI CAMMINATA VERSO DESTRA
    {
        if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && isActor1OnTheGround == true) //SE NON STA SALTANDO E SI TROVA SUL TERRENO, MANDA L'ANIMAZIONE WALK
        {
            animazione.Play("walk");
        }

        if (isRiight == false) //SE NON STA ANDANDO VERSO DESTRA, RUOTA IL PLAYER

            //se il player è rivolto a sinistra
            if (isRiight == false)

            {
                //si gira a destra
                transform.Rotate(0, 180f, 0);
                isRiight = true;
            }
        player.transform.Translate(walkingSpeed * Time.deltaTime, 0, 0, Space.World);
    }

    private void WalkLeft() //CORRISPETTIVO DI WALKRIGHT MA VERSO SINISTRA
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
        player.transform.Translate(-walkingSpeed * Time.deltaTime, 0, 0, Space.World);
    }

    public void ShiftDimension()
    {
        if (player.velocity.y == 0)
        {
            animazione.Play("shift");
            StartCoroutine(IntervalloRicaricaScena());
        }
    }

    private bool IsGrounded()
    {
        float extraHeight = .1f;
        RaycastHit2D rayCastHit = Physics2D.BoxCast(boxCollider.bounds.center, boxCollider.bounds.size, 0f, Vector2.down, extraHeight, platformLayerMask);
        Color rayColor;
        if(rayCastHit.collider != null)
        {
            rayColor = Color.green;
        }
        else
        {
            rayColor = Color.red;
        }
        
        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraHeight), Vector2.right * boxCollider.bounds.extents.x, rayColor);
        return rayCastHit.collider != null;
    }

    IEnumerator IntervalloRicaricaScena()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.2f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        if (SceneManager.GetActiveScene().name == "MG_lvl1")
        {

            SceneManager.LoadScene("MG_lvl1Void");
        }
        else if (SceneManager.GetActiveScene().name == "MG_lvl1Void")
        {
            SceneManager.LoadScene("MG_lvl1");
        }
    }

}
