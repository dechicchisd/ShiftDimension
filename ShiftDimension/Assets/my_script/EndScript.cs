using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScript : MonoBehaviour
{
    public GameObject endText;
    public GameObject endPanel;
    public float delayToText;
    public float delayToPanel;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        StartCoroutine(End());
    }

    IEnumerator End()
    {
        yield return new WaitForSeconds(delayToText);

        endText.SetActive(true);

        yield return new WaitForSeconds(delayToPanel);

        endPanel.SetActive(true);
    }
}
