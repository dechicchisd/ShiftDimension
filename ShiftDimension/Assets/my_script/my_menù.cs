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

    public void PlayGame()
    {
        SceneManager.LoadScene("MG_Scena_Sample");
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
