using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Networking; 

public class AccountManagement : MonoBehaviour
{
    public Button RegisterButton;
    public InputField emailField;
    public InputField pswField;

    public void CallRegister()
    {
        StartCoroutine(Register());
    }


    IEnumerator Register()
    {
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("pass", pswField.text);
        UnityWebRequest www = new UnityWebRequest("https://mysql.aruba.it/login/index.php?lang=it-iso-8859-1");
        yield return www;


    }
}
