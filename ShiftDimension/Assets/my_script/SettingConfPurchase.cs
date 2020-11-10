using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SettingConfPurchase : MonoBehaviour
{
    public Sprite spriteToUse;
    public Image imgToChange;
    public TextMeshProUGUI costToChange;
    public int costToUse;

    public void Set()
    {
        imgToChange.sprite = spriteToUse;
        costToChange.text = costToUse.ToString();   
    }

}
