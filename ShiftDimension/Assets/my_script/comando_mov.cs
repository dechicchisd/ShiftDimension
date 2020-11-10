using System.Collections;
using System.Collections.Generic;
using System.Collections.Specialized;
using System.Threading;
using UnityEngine;
using UnityEngine.EventSystems;

public class comando_mov : MonoBehaviour
{

    //DICHIARO LE VARIABILI

    public Rigidbody2D player;  //PLAYER
    public Vector2 m_NewForce = new Vector2(0, 30f);    //FORZA DEL SALTO
    public Animator animazione; //ANIMATORE DEL PLAYER
    public bool isActor1OnTheGround = true; //VARIABILE CHE MI DICE SE IL PLAYER SI TROVA SUL TERRENO O IN ARIA
    public bool isRiight = true;    //VARIABILE CHE MI DICE SE IL PLAYER SI STA MUOVENDO VERSO DESTRA O SINISTRA
    public static float altezzaCorrente;    //VARIABILE CHE MI RITORNA L'ALTEZZA CORRENTE DEL PLAYER (SI AGGIORNA OGNI FRAME)
    public BoxCollider2D playerCollider;    //BOXCOLLIDER2D DEL PLAYER

    public ForceMode2D salto;
    public float t;
    private float walkingSpeed = 0.01f;


    // Start is called before the first frame update
    void Start()    //INIZIALIZZO L'ANIMATORE DEL PLAYER E ACQUISISCO LA PRIMA ALTEZZA DEL PLAYER
    {
        animazione = GetComponent<Animator>();  
        altezzaCorrente = player.position.y;    
    }

    // Update is called once per frame
    void Update()
    {
        if(player.position.y < altezzaCorrente) //SE IL PLAYER STA CADENDO FACCIO PARTIRE L'ANIMAZIONE LAND
        {
            animazione.Play("land");
            isActor1OnTheGround = false;
        }
        if (Input.GetKeyDown("space") && isActor1OnTheGround == true && !(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump"))) //SE VIENE PREMUTO SPAZIO && IL PLAYER è SUL TERRENO && NON STA GIà SALTANDO, ALLORA SALTA
        {
            jumpAction();
        }

        else if (Input.GetKey("d")) //SE VIENE PREMUTO IL TASTO D CAMMINA VERSO DESTRA
        {
            walkRight();
        }
        else if (Input.GetKey("a")) //SE VIENE PREMUTO IL TASTO A CAMMINA VERSO SINISTRA
        {
            walkLeft();
        }
        else if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && !(animazione.GetCurrentAnimatorStateInfo(0).IsName("land"))) //SE NON VIENE PREMUTO NULLA E L'ANIMAZIONE CORRENTE NON è JUMP O LAND, FAI ANDARE L'ANIMAZIONE REST
        {
            animazione.Play("rest");
        }
        altezzaCorrente = player.position.y; //AGGIORNA L'ALTEZZA CORRENTE DEL PLAYER

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
    }

    void OnCollisionStay2D(Collision2D collision) //VIENE CHIAMATA SE STA AVVENENDO UNA COLLISIONE CONTINUA TRA DUE COLLIDER
    {
        if (collision.gameObject.tag == "Ground") //SE IL PLAYER STA COLLIDENDO CON UN OGGETTO CON TAG GROUND, ATTIVA LA VARIABILE A TRUE
        {
            isActor1OnTheGround = true;
        }
    }

    private void jumpAction() //FUNZIONE DI SALTO
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

    private void walkRight() //FUNZIONE DI CAMMINATA VERSO DESTRA
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
        player.transform.Translate(walkingSpeed, 0, 0);
    }

    private void walkLeft() //CORRISPETTIVO DI WALKRIGHT MA VERSO SINISTRA
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
