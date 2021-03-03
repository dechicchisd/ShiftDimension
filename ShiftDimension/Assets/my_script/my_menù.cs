using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class my_menù : MonoBehaviour
{
    public void ChooseGameMode()
    {
        SceneManager.LoadScene("MG_PlayMode");
    }

    public void GoToShop()
    {
        SceneManager.LoadScene("DD_Shop");
    }

    public void PlayLevel1()
    {
        SceneManager.LoadScene("Livello_1");
    }

    public void PlayLevel2()
    {
        SceneManager.LoadScene("Livello_2");
    }

    public void PlayLevel3()
    {
        SceneManager.LoadScene("Livello_3");
    }

    public void ChooseLevel()
    {
        SceneManager.LoadScene("MG_Levels");
    }

    public void BackScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex - 1);
    }
}
