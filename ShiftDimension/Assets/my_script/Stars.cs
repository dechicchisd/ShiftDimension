using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public float randomNumSize;
    public float randomNumRotation;
    public Vector3 scaleChange;
    public Vector3 scaleChangeDispari;
    public bool isPari = false;
    public static int count = 0;

    // Start is called before the first frame update
    void Start()
    {
        randomNumSize = Random.Range(1, 3);
        randomNumRotation = Random.Range(0, 360);
        scaleChange = new Vector3(randomNumSize, randomNumSize, randomNumSize);
        scaleChangeDispari = new Vector3(0.5f, 0.5f, 0.5f);
        transform.localScale = scaleChange;
    }

    // Update is called once per frame
    void Update()
    {
        if(isPari == false && count > 60)
        {
            isPari = true;
            count = 0;
            transform.localScale -= scaleChangeDispari;
        }
        else if (count > 60)
        {
            isPari = false;
            count = 0;
            transform.localScale += scaleChangeDispari;
        }
        count++;
    }
}
