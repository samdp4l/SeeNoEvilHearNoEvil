using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public UnitSanity playerSanity = new UnitSanity(100, 100);
    public UnitStamina playerStamina = new UnitStamina(100f, 100f, 35f, false);

    void Awake()
    {
        if (gameManager == null)
        {
            gameManager = this;
        }

        DontDestroyOnLoad(gameObject);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (gameManager != null && gameManager != this)
        {
            Destroy(gameObject);
        }
    }
}