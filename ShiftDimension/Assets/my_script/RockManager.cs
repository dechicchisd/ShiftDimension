using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RockManager : MonoBehaviour
{
    public Rigidbody2D rock;
    public Vector2 pos;
    public float destroyTime;
    public float readyTime;
    private bool triggerReady = true;
    private Rigidbody2D clone;

    private void Update()
    {
        if (clone != null && clone.velocity.x <= 0)
        {
            //StartCoroutine(WaitAndDestroy(destroyTime, readyTime));
            Destroy(clone, 2.1f);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (triggerReady)
        {
            clone = Instantiate(rock, pos, Quaternion.identity);
            triggerReady = false;
        }
    }

    IEnumerator WaitAndDestroy(float waitTime, float readyTime)
    {
        yield return new WaitForSeconds(waitTime);
        
        Destroy(clone);
        yield return new WaitForSeconds(waitTime);
        triggerReady = true;

    }
}
