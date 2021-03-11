using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class UIManager : MonoBehaviour
{
    public static UIManager instance;

    //Screen object variables
    public GameObject loginUI;
    public GameObject registerUI;
    public GameObject accountUI;
    public GameObject background;
    public GameObject info;



    private void Start()
    {
        var username = PlayerPrefs.GetString("username");
        Debug.Log(username);
        TextMeshProUGUI hello = info.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        TextMeshProUGUI coins = info.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();

        if (username == "")
        {
            accountUI.SetActive(true);
            background.SetActive(true);
            info.SetActive(false);
        }

        else
        {
            hello.text = "Hello, " + PlayerPrefs.GetString("username") + "!";
            coins.text = PlayerPrefs.GetFloat("coins").ToString("0");
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else if (instance != null)
        {
            Debug.Log("Instance already exists, destroying object!");
            Destroy(this);
        }
    }

    private void Update()
    {
        if (PlayerPrefs.GetString("username") == "")
        {
            info.SetActive(false);
            accountUI.SetActive(true);
            background.SetActive(true);
        }
        else
        {
            info.SetActive(true);
            accountUI.SetActive(false);
            background.SetActive(false);
        }
    }

    //Functions to change the login screen UI
    public void LoginScreen() //Back button
    {
        loginUI.SetActive(true);
        registerUI.SetActive(false);
    }
    public void RegisterScreen() // Regester button
    {
        loginUI.SetActive(false);
        registerUI.SetActive(true);
    }
}