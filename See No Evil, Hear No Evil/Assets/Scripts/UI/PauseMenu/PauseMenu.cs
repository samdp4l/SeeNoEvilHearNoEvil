using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;

    /*public GameObject chimeMonsterInfo;
    public GameObject stalkerMonsterInfo;

    public GameObject objective1;
    public GameObject objective2;
    public GameObject objective3;
    public GameObject objective4;
    public GameObject objective5;

    public GameObject journalText1;
    public GameObject journalText2;
    public GameObject journalText3;
    public GameObject journalText4;
    public GameObject journalText5;
    public GameObject journalText6;
    public GameObject journalText7;
    public GameObject journalText8;
    public GameObject journalText9;
    public GameObject journalText10;
    public GameObject journalText11;
    public GameObject journalText12;*/

    public List<GameObject> entries;

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
        SceneManager.LoadScene("Main Menu");

    }
    public void QuitGame()
    {
        Application.Quit();
    }

    public void UnlockEntry(int entry)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (i == entry)
            {
                entries[i].SetActive(true);
            }
        }

        /*if (entry == 0)
        {
            objective1.SetActive(true);
        }
        else if (entry == 1)
        {
            objective2.SetActive(true);
        }
        else if (entry == 2)
        {
            objective3.SetActive(true);
        }
        else if (entry == 3)
        {
            objective4.SetActive(true);
        }
        else if (entry == 4)
        {
            objective5.SetActive(true);
        }
        else if (entry == 5)
        {
            journalText1.SetActive(true);
        }
        else if (entry == 6)
        {
            journalText2.SetActive(true);
        }
        else if (entry == 7)
        {
            journalText3.SetActive(true);
        }
        else if (entry == 8)
        {
            journalText4.SetActive(true);
        }
        else if (entry == 9)
        {
            journalText5.SetActive(true);
        }
        else if (entry == 10)
        {
            journalText6.SetActive(true);
        }
        else if (entry == 10)
        {
            journalText7.SetActive(true);
        }
        else if (entry == 11)
        {
            journalText8.SetActive(true);
        }
        else if (entry == 12)
        {
            journalText9.SetActive(true);
        }
        else if (entry == 13)
        {
            journalText10.SetActive(true);
        }
        else if (entry == 14)
        {
            journalText11.SetActive(true);
        }
        else if (entry == 15)
        {
            journalText12.SetActive(true);
        }
        else if (entry == 16)
        {
            chimeMonsterInfo.SetActive(true);
        }
        else if (entry == 17)
        {
            stalkerMonsterInfo.SetActive(true);
        }*/
    }
}
