using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClasseStatica : MonoBehaviour
{

    public float altezzaCorrente;    //VARIABILE CHE MI RITORNA L'ALTEZZA CORRENTE DEL PLAYER (SI AGGIORNA OGNI FRAME)
    public float altezzaInizio;    //VARIABILE CHE MI RITORNA L'ALTEZZA CORRENTE DEL PLAYER (SI AGGIORNA OGNI FRAME)
    public float distanzaCorrente;    //VARIABILE CHE MI RITORNA LA DISTANZA PERCORSA CORRENTE DEL PLAYER (SI AGGIORNA OGNI FRAME)
    public float distanzaInizio;    //VARIABILE CHE MI RITORNA LA DISTANZA INIZIALEDEL LIVELLO (SI AGGIORNA OGNI FRAME)
    public Rigidbody2D inizioLivello;
    public static float delta;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void setAltezzaCorrente(float h)
    {
        altezzaCorrente = h;
    }

    public void setAltezzaIniziale(float h)
    {
        altezzaCorrente = h;
    }

    public void setDistanzaIniziale(float d)
    {
        distanzaInizio = d;
    }

    public void setDistanzaCorrente(float d)
    {
        distanzaCorrente = d;
    }

    public float getAltezzaCorrente()
    {
        return altezzaCorrente;
    }

    public float getDistanzaCorrente()
    {
        return distanzaCorrente;
    }

    public float getDistanzaIniziale()
    {
        return distanzaInizio;
    }

    public float getAltezzaIniziale()
    {
        return altezzaInizio;
    }

    public float getDeltaX()
    {
        return distanzaCorrente - distanzaInizio;
    }

    public float getDeltaY()
    {
        return altezzaInizio - altezzaCorrente;
    }

}
