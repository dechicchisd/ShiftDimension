using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class alt_mov : MonoBehaviour
{
    public Rigidbody2D pl;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown("space"))
        {
            pl.AddForce(new Vector2(0, 20), ForceMode2D.Impulse);
        }

        else if (Input.GetKey("d"))
        {
            transform.Translate(0.07f, 0, 0);
        }
        else if (Input.GetKey("a"))
        {
            transform.Translate(-0.07f, 0, 0);
        }
    }
}
