using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour
{

    public Rigidbody2D player;
    public Rigidbody2D veg;
    public Rigidbody2D inizioNullsx;
    public Rigidbody2D fineNullsx;
    public Rigidbody2D inizioNulldx;
    public Rigidbody2D fineNulldx;
    private Vector3 posizione;
    public Vector3 offsetVeg;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player != null)
        {
            if (player.position.x > posizione.x && veg.position.x < fineNullsx.position.x)
            {
                transform.position = new Vector2(inizioNulldx.position.x + (veg.position.x - inizioNullsx.position.x), veg.position.y);
            }

            else if (player.position.x < posizione.x && veg.position.x > inizioNulldx.position.x)
            {
                transform.position = new Vector2(fineNullsx.position.x + (veg.position.x - fineNulldx.position.x), veg.position.y);
            }

            posizione.x = player.position.x;
        }
    }
}
