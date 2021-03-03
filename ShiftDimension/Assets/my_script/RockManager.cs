using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    public GameObject rock;
    public Vector2 pos;
    public float destroyTime;
    public float readyTime;
    private bool triggerReady = true;
    private GameObject clone;
    private Rigidbody2D rb;

    private void OnTriggerEnter2D(Collider2D collision)
    {

        if (triggerReady)
        {
            rb = Instantiate(rock.GetComponent<Rigidbody2D>(), pos, Quaternion.identity);
            clone = rb.gameObject;
            triggerReady = false;
            Destroy(clone, destroyTime);
            StartCoroutine(TriggerUp(readyTime));
        }
        
    }

    IEnumerator TriggerUp(float readyTime)
    {
        yield return new WaitForSeconds(readyTime);
        triggerReady = true;



    }
}
