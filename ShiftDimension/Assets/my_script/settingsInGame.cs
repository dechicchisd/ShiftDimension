using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class settingsInGame : MonoBehaviour
{

    public GameObject settingPanel;
    public GameObject background;

    void start()
    {
        settingPanel.SetActive(false);
    }

    public void pauseGame()
    {
        settingPanel.SetActive(true);
        background.SetActive(true);
        Time.timeScale = 0.0f;
    }

    public void unpauseGame()
    {
        settingPanel.SetActive(false);
        background.SetActive(false);
        Time.timeScale = 1.0f;
    }

    public void tornaAlMenu()
    {
        SceneManager.LoadScene("MG_PlayMode");
    }
}
