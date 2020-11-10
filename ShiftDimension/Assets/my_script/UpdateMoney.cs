using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UpdateMoney : MonoBehaviour
{
    public TextMeshProUGUI myTextCoins;
    public TextMeshProUGUI priceText;
    private float desiredCoins;
    private float currentCoins;
    private float initialCoins;
    private float animationTime = 1.5f;


    // Start is called before the first frame update

    public void Start()
    {
        initialCoins = System.Single.Parse(myTextCoins.text);
        desiredCoins = initialCoins;
        currentCoins = initialCoins;
    }

    public void DecreaseCoins()
    {
        desiredCoins = currentCoins - System.Single.Parse(priceText.text);
    }

    public void Update()
    {

        if ((desiredCoins < currentCoins) && (desiredCoins >= 0))
        {
            currentCoins -= (animationTime * Time.deltaTime) * (initialCoins - desiredCoins);
            if (currentCoins <= desiredCoins)
                currentCoins = desiredCoins;
        }
        myTextCoins.text = currentCoins.ToString("0");
    }


}
