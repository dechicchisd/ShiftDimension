using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AcidLifetime : MonoBehaviour
{
    
    //una volta creato l'oggetto acid viene controllato da questo script, che ne disegna la posizione con drawray, e lo distrugge dopo 2 sec
    void Update()
    {
        float xLeft = GetComponent<Collider2D>().bounds.center.x - GetComponent<Collider2D>().bounds.extents.x;
        float yLeft = GetComponent<Collider2D>().bounds.center.y;
        Debug.DrawRay(new Vector2(xLeft, yLeft), Vector2.right * 10, Color.magenta);
        Destroy(this.gameObject, 2f);
    }
}
