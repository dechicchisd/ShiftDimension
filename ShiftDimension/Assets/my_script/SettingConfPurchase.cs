using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingConfPurchase : MonoBehaviour
{
    public Sprite spriteToUse;
    public Image imgToChange;
    public GameObject overlay;
    public Button skinButton;
    public TextMeshProUGUI costToChange;
    public TextMeshProUGUI currentMoney;
    public int costToUse;


    public void Update()
    {
        if(System.Single.Parse(currentMoney.text) < costToUse)
        {
            overlay.SetActive(true);
            skinButton.interactable = false;
        }
    }
    public void Set()
    {
        imgToChange.sprite = spriteToUse;
        costToChange.text = costToUse.ToString();   
    }

}
