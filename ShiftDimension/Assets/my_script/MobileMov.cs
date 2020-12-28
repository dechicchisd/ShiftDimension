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
    private bool isDead = false;
    public static bool isShifting;
    public Rigidbody2D player;
    public Vector2 m_NewForce = new Vector2(0, 30f);
    public Animator animazione;
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
    public GameObject deathPanel;
    public BoxCollider2D playerCollider;


    // Start is called before the first frame update
    void Start()
    {
        if(isShifting == false)
        {
            transform.position = inizioLivello.position + new Vector2(0, 2f);
        }
        else
        {
            StartCoroutine(IntervalloRicaricaScenaPost());
        }
        animazione = GetComponent<Animator>();
        animazione.Play("rest");
        boxCollider = transform.GetComponent<BoxCollider2D>();
        isDead = false;
    }

  //  /* ---------------------- USO DELLA TASTIERA --------------------------
    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded() && player.position.y < altezzaCorrente && isDead == false && isShifting == false)
        {
            animazione.Play("land");
        }
        else if (!IsGrounded() && player.position.y > altezzaCorrente && isDead == false && isShifting == false)
        {
            animazione.Play("jump");
        }
        if (Input.GetKeyDown("space") && IsGrounded() && !(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && isShifting == false) //SE VIENE PREMUTO SPAZIO && IL PLAYER è SUL TERRENO && NON STA GIà SALTANDO, ALLORA SALTA
        {
            JumpAction();
        }
        else if (Input.GetKey("d") && isDead == false && isShifting == false) //SE VIENE PREMUTO IL TASTO D CAMMINA VERSO DESTRA
        {
            WalkRight();
        }
        else if (Input.GetKey("a") && isDead == false && isShifting == false) //SE VIENE PREMUTO IL TASTO A CAMMINA VERSO SINISTRA
        {
            WalkLeft();
        }
        else if (IsGrounded() && isDead == false && isShifting == false) //SE NON VIENE PREMUTO NULLA E L'ANIMAZIONE CORRENTE NON è JUMP O LAND, FAI ANDARE L'ANIMAZIONE
        {
            animazione.Play("rest");
        }
        else if(isDead == true)
        {
            animazione.Play("death");
        }
        if(isDead == false)
        {
            altezzaCorrente = player.position.y; //AGGIORNA L'ALTEZZA CORRENTE DEL PLAYER
            distanzaCorrente = player.position.x;
        }

    }
  // a   */
    /* ------------------------------------------ USO DEL JOYSTIC E PULSANTI -------------------------------------
    // Update is called once per frame
    void Update()
    {
        if (!IsGrounded() && player.position.y < altezzaCorrente && isDead == false && isShifting == false)
        {
            animazione.Play("land");
        }
        else if(!IsGrounded() && player.position.y > altezzaCorrente && isDead == false && isShifting == false)
        {
            animazione.Play("jump");
        }

        if (joystick.Horizontal >= .2f && isDead == false && isShifting == false)
        {
            WalkRight();
        }
        else if (joystick.Horizontal <= -.2f && isDead == false && isShifting == false)
        {
            WalkLeft();
        }
        else if (IsGrounded() && isDead == false && isShifting == false) //SE NON VIENE PREMUTO NULLA E L'ANIMAZIONE CORRENTE NON è JUMP O LAND, FAI ANDARE L'ANIMAZIONE
        {
            animazione.Play("rest");
        }
        else if (isDead == true)
        {
            animazione.Play("death");
        }
        if (isDead == false)
        {
            altezzaCorrente = player.position.y; //AGGIORNA L'ALTEZZA CORRENTE DEL PLAYER
            distanzaCorrente = player.position.x;
        }

    }
   */

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
        

        if (collision.gameObject.tag == "Enemy")
        {
            if (collision.contacts[0].point.y == collision.contacts[1].point.y) //SE DUE PUNTI DI COLLISIONE CONSECUTIVI HANNO LA STESSA Y ALLORA LA COLLISIONE
                                                                                //è SULLA FACCIA SUPERIORE DEL NEMICO
            {
                player.AddForce(new Vector2(0, collidingForce), ForceMode2D.Impulse);
                Destroy(collision.gameObject);
            }

            else
            {
                distanzaCorrente = 0;
                altezzaCorrente = 0;
                playerCollider.enabled = false;
                player.constraints = RigidbodyConstraints2D.FreezePosition;
                isDead = true;
                StartCoroutine(IntervalloMorte(1.1f));
            }
        }

        if(collision.gameObject.tag == "Death")
        {
            distanzaCorrente = 0;
            altezzaCorrente = 0;
            deathPanel.SetActive(true);
            Destroy(this.gameObject);
        }

        
    }
    
   IEnumerator IntervalloMorte(float waitTime)
   {
       //Print the time of when the function is first called.
       Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(waitTime);

       deathPanel.SetActive(true);
       Destroy(this.gameObject);

       //After we have waited 5 seconds print the time again.
       Debug.Log("Finished Coroutine at timestamp : " + Time.time);


   }
   


    public void JumpAction() //FUNZIONE DI SALTO
    { 
        if(IsGrounded())
        {
            player.AddForce(m_NewForce, ForceMode2D.Impulse);
        }
        

    }

    private void WalkRight() //FUNZIONE DI CAMMINATA VERSO DESTRA
    {
        if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && IsGrounded() && isDead == false) //SE NON STA SALTANDO E SI TROVA SUL TERRENO, MANDA L'ANIMAZIONE WALK
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
        if (!(animazione.GetCurrentAnimatorStateInfo(0).IsName("jump")) && IsGrounded())
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
            isShifting = true;
            animazione.Play("shift");
            player.constraints = RigidbodyConstraints2D.FreezePosition;
            StartCoroutine(IntervalloRicaricaScena());
        }
    }

    IEnumerator IntervalloRicaricaScena()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.1f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);
        if (SceneManager.GetActiveScene().name == "MG_Scena_Sample")
        {

            SceneManager.LoadScene("MG_Scena_Sample_Void");
        }
        else if (SceneManager.GetActiveScene().name == "MG_Scena_Sample_Void")
        {
            SceneManager.LoadScene("MG_Scena_Sample");
        }
        else if (SceneManager.GetActiveScene().name == "MG_lvl1")
        {

            SceneManager.LoadScene("MG_lvl1Void");
        }
        else if (SceneManager.GetActiveScene().name == "MG_lvl1Void")
        {
            SceneManager.LoadScene("MG_lvl1");
        }
        else if (SceneManager.GetActiveScene().name == "Livello_1")
        {

            SceneManager.LoadScene("Livello_1Void");
        }
        else if (SceneManager.GetActiveScene().name == "Livello_1Void")
        {
            SceneManager.LoadScene("Livello_1");
        }
    }

    IEnumerator IntervalloRicaricaScenaPost()
    {
        //Print the time of when the function is first called.
        Debug.Log("Started Coroutine at timestamp : " + Time.time);

        
        nuovaPosizione = new Vector2(distanzaCorrente, altezzaCorrente + 1.1f);
        /*player.MovePosition(nuovaPosizione);*/
        transform.position = nuovaPosizione;

        animazione.Play("shift_reversed");

        //yield on a new YieldInstruction that waits for 5 seconds.
        yield return new WaitForSeconds(1.1f);

        //After we have waited 5 seconds print the time again.
        Debug.Log("Finished Coroutine at timestamp : " + Time.time);

        isShifting = false;
    }

    //controlla che il player tocchi terra 
    private bool IsGrounded()
    {
        //allungo la hitbox verso il basso per non far buggare le animazioni in discesa
        float extraHeight = .36f;
        //crea una hitbox da cui posso controllare se il player sta toccando collider
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
       
        //disegna l'hitbox con del player e diventa rossa quando non collide con nulla altrimenti verde
        Debug.DrawRay(boxCollider.bounds.center + new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, 0), Vector2.down * (boxCollider.bounds.extents.y + extraHeight), rayColor);
        Debug.DrawRay(boxCollider.bounds.center - new Vector3(boxCollider.bounds.extents.x, boxCollider.bounds.extents.y + extraHeight), Vector2.right * boxCollider.bounds.extents.x * 2, rayColor);

        bool ground = false;
        if (rayCastHit.collider != null)
            ground = rayCastHit.collider.tag == "Ground";
        
        return ground;
    }

    

    

    

}
