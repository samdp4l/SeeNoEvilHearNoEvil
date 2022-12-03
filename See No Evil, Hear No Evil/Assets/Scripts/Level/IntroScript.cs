using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class IntroScript : MonoBehaviour
{
    public GameObject continueText;
    public GameObject cutsceneScreen;
    public GameObject loadingScreen;
    public AudioSource clickSound;

    private bool cutsceneEnded = false;

    void Start()
    {
        Invoke("CutsceneEnd", 10f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return) && cutsceneEnded == true)
        {
            cutsceneScreen.SetActive(false);
            loadingScreen.SetActive(true);

            clickSound.Play();

            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }

    void CutsceneEnd()
    {
        cutsceneEnded = true;
        continueText.SetActive(true);
    }
}
