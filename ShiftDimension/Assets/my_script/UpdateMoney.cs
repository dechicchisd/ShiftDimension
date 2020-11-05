using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using UnityEngine.SceneManagement;

public class UpdateMoney : MonoBehaviour
{
    public TextMeshProUGUI startingMoney;
    public TextMeshProUGUI priceText;
    private int endMoney;
    private int currentMoney;
    private bool isDecreasing = false;
    public Button bottone;
    private IEnumerator ien;
    // Start is called before the first frame update

   

    public void SettingMoney()
    {
        int startMoney = System.Int16.Parse(startingMoney.text);
        int currentMoney = startMoney - System.Int16.Parse(priceText.text);
        startingMoney.text = currentMoney.ToString();
    }

}
