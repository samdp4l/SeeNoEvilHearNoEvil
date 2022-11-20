using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;
    public GameObject stalkerMonsterInfo;
    public GameObject chimeMonsterInfo;
    public GameObject secondObjective;
    public GameObject thirdObjective;
    public GameObject journalText1;
    public GameObject journalText2;
    public GameObject journalText3;
    public GameObject journalText4;

    private GameObject player;
    private GameObject gameManager;

    private void Awake()
    {
        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (GameisPaused)
            {
                Resume();
            }
            else
            {
                Pause();
            }

        }
    }
    public void Resume()
    {
        player.SetActive(true);
        pauseMenuUI.SetActive(false);
        gameManager.GetComponent<AudioListener>().enabled = false;

        Time.timeScale = 1f;
        GameisPaused = false;
    }
    void Pause()
    {
        player.SetActive(false);
        pauseMenuUI.SetActive(true);
        gameManager.GetComponent<AudioListener>().enabled = true;

        Time.timeScale = 0f;
        GameisPaused = true;
    }

    public void LoadMenu()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("Menu");

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void unlockSecondObjective()
    {
        secondObjective.SetActive(true);
    }

    public void unlockThirdObjective()
    {
        thirdObjective.SetActive(true);
    }

    public void unlockStalker()
    {
        stalkerMonsterInfo.SetActive(true);
    }

    public void unlockChime()
    {
        chimeMonsterInfo.SetActive(true);
    }

    public void unlockText1()
    {
        journalText1.SetActive(true);
    }

    public void unlockText2()
    {
        journalText2.SetActive(true);
    }

    public void unlockText3()
    {
        journalText3.SetActive(true);
    }

    public void unlockText4()
    {
        journalText4.SetActive(true);
    }
}
