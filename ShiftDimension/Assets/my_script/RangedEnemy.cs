using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangedEnemy : Enemy
{
    public GameObject obj;
    public Rigidbody2D player;
    public Rigidbody2D leftRange;
    public Rigidbody2D rightRange;
    public Vector2 throwVel;
    private Rigidbody2D rb;
    private GameObject newObj;
    private bool canThrow;
    private bool left;
    


    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
        rb = obj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    protected override void Update()
    {
        if (player != null && player.position.x > leftRange.position.x && player.position.x < rightRange.position.x && canThrow)
        {
            StartCoroutine(Throw());
            if (newObj != null)
            {
                Destroy(newObj, 4);
            }
        }
    }

    private bool IsLeft()
    {
        return player.position.x > transform.position.x;
    }

    IEnumerator Throw()
    {
        canThrow = false;
        if (IsLeft())
        {
            newObj = Instantiate(obj, new Vector2(transform.position.x - 1, transform.position.y + 2), Quaternion.identity);
            Rigidbody2D newRb = newObj.GetComponent<Rigidbody2D>();
            newRb.velocity = throwVel;
        }

        else if (!IsLeft())
        {
            newObj = Instantiate(obj, new Vector2(transform.position.x - 1, transform.position.y + 2), Quaternion.identity);
            Rigidbody2D newRb = newObj.GetComponent<Rigidbody2D>();
            newRb.velocity = new Vector2(-throwVel.x, throwVel.y);
        }
        yield return new WaitForSeconds(5);
        canThrow = true;
    }
}
