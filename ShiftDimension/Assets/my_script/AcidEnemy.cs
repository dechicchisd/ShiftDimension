using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//sottoclasse di enemy
public class AcidEnemy : Enemy
{
    public GameObject acid;
    private GameObject acidClone;


    //quando ucciso il nemico istanzia il prefab acid e poi invoca il metodo dies() della superclasse
    public override void Dies()
    {
        float ypos = GetComponent<Collider2D>().bounds.center.y - GetComponent<Collider2D>().bounds.size.y/2 + 0.2f;
        float xpos = transform.position.x;
        acid = Instantiate(acid, new Vector2(xpos, ypos), Quaternion.identity);
        base.Dies();
    }
}
