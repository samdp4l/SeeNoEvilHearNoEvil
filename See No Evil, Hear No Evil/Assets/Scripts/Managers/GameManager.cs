using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager gameManager { get; private set; }

    public UnitSanity playerSanity = new UnitSanity(100, 100);
    public UnitStamina playerStamina = new UnitStamina(100f, 100f, 35f, false);

    void Awake()
    {
        if (gameManager != null && gameManager != this)
        {
            Destroy(this);
        }
        else
        {
            gameManager = this;
        }

        DontDestroyOnLoad(gameObject);
    }
}