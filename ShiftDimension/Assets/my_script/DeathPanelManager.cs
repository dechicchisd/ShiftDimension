using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class DeathPanelManager : MonoBehaviour
{

    public void Restart()
    {
        if (SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByName("Livello_1_void").buildIndex)
        {
            SceneManager.LoadScene("Livello_1");
        }

        else if (SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByName("Livello_2_void").buildIndex)
        {
            SceneManager.LoadScene("Livello_2");
        }

        else if (SceneManager.GetActiveScene().buildIndex == SceneManager.GetSceneByName("Livello_3_void").buildIndex)
        {
            SceneManager.LoadScene("Livello_3");
        }

        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

    public void Exit()
    {
        SceneManager.LoadScene("MG_PlayMode");
    }

}
