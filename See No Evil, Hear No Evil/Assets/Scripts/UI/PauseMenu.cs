using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour
{
    public static PauseMenu instance;
    public static bool GameisPaused = false;

    public GameObject pauseMenuUI;
    public AudioSource openSound;
    public AudioSource closeSound;

    public List<GameObject> entries;

    private GameObject player;
    private GameObject gameManager;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(this);
        }

        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager");

        DontDestroyOnLoad(this);
    }

    private void OnLevelWasLoaded()
    {
        instance.pauseMenuUI.SetActive(false);

        player = GameObject.Find("Player");
        gameManager = GameObject.Find("Game Manager");

        GameisPaused = false;
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
        instance.pauseMenuUI.SetActive(false);

        closeSound.Play();
        gameManager.GetComponent<AudioListener>().enabled = false;

        Time.timeScale = 1f;
        GameisPaused = false;
    }
    void Pause()
    {
        player.SetActive(false);
        instance.pauseMenuUI.SetActive(true);

        openSound.Play();
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

    public void UpdateJournal(int entry)
    {
        for (int i = 0; i < entries.Count; i++)
        {
            if (i == entry)
            {
                entries[i].SetActive(true);
            }
        }
    }
}
