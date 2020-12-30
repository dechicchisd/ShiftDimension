using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowClouds : MonoBehaviour
{
    public bool isRunning = false;

    public Rigidbody2D cloud;
    public Rigidbody2D originalCloud;
    public Rigidbody2D posizioneOriginale;
    public Vector2 initPosition;
    public float randomNum;
    public float randomPos;
    public float randomPosY;
    public Vector3 scaleChange;

    public float walkingSpeed;

    // Start is called before the first frame update
    void Start()
    {
        randomNum = Random.Range(0, 10000);
        randomPos = Random.Range(0, 5);
        randomPosY = Random.Range(-1, 4);
        initPosition = new Vector2(originalCloud.position.x, posizioneOriginale.position.y + randomPosY);
        transform.position = initPosition;
        scaleChange = new Vector3((3 - randomPosY) / 2, (3 - randomPosY) / 2, 0);
        transform.localScale += scaleChange;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = initPosition;
        initPosition = new Vector2(originalCloud.position.x, posizioneOriginale.position.y + randomPosY);

    }
}


/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vegetation : MonoBehaviour
{

    public Rigidbody2D veg;
    public Rigidbody2D posizioneOriginale;
    public Vector2 initPosition;
    public float randomPos;
    public float randomPosY;
    public Vector3 scaleChange;


    // Start is called before the first frame update
    void Start()
    {
        randomPos = Random.Range(0, 860);
        randomPosY = Random.Range(-8, 8);
        initPosition = new Vector2(posizioneOriginale.position.x + randomPos, posizioneOriginale.position.y + randomPosY);
        transform.position = initPosition;
        scaleChange = new Vector3((8 - randomPosY)/1.5f, (8 - randomPosY)/1.5f, 0);
        transform.localScale += scaleChange;
    }
}
*/

