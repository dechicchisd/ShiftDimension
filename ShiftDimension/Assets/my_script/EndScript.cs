using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class EndScript : MonoBehaviour
{
    public GameObject endText;
    public GameObject endPanel;
    public float delayToText;
    public float delayToPanel;
    public TextMeshProUGUI currentCoins;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(End());
        PlayerPrefs.SetFloat("coins", System.Single.Parse(currentCoins.text));
        Debug.Log("Coin: " + PlayerPrefs.GetFloat("coins"));

    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(delayToText);

        endText.SetActive(true);

        yield return new WaitForSeconds(delayToPanel);

        endPanel.SetActive(true);
    }
}
