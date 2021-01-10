using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Throw : MonoBehaviour
{
    public GameObject obj;
    public Rigidbody2D player;
    public Rigidbody2D leftBound;
    public Rigidbody2D rightBound;
    private Rigidbody2D rb;
    private bool canThrow;


    // Start is called before the first frame update
    void Start()
    {
        canThrow = true;
        rb = obj.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player.position.x > leftBound.position.x && player.position.x < rightBound.position.x && canThrow)
        {
            StartCoroutine(Reload());
        }
    }

    IEnumerator Reload()
    {
        canThrow = false;
        yield return new WaitForSeconds(2f);
        GameObject newObj = Instantiate(obj, new Vector2(transform.position.x - 1, transform.position.y + 2), Quaternion.identity);
        Rigidbody2D newRb = newObj.GetComponent<Rigidbody2D>();
        newRb.velocity = new Vector2(4, 6);
        canThrow = true;
    }
}
