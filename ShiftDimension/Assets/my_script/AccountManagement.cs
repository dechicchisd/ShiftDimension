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
        string url = "https://mysql.aruba.it/login/index.php?lang=it-iso-8859-1";
        WWWForm form = new WWWForm();
        form.AddField("email", emailField.text);
        form.AddField("pass", pswField.text);
        UnityWebRequest www = UnityWebRequest.Post(url, form); ;
        yield return www.SendWebRequest();

        if(www.isNetworkError || www.isHttpError)
        {
            Debug.Log(www.error);
        }
        else
        {
            Debug.Log("Record Added!\n");
        }


    }
}
