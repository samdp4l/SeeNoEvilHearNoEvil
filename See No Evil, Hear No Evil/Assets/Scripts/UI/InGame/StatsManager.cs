using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StatsManager : MonoBehaviour
{
    [SerializeField]SanityBar sanityBar;
    [SerializeField]StaminaBar staminaBar;
    [SerializeField]PlayerMovement playerMove;

    public float gracePeriod = 3f;
    public float healFreq = 0.5f;
    public int healAmount = 1;
    public float dotTimer = 60f;
    public float dotFreq = 1f;
    public int dotDmg = 5;
    [HideInInspector]
    public bool healthDot = false;

    private bool playerGrace = false;

    private void Start()
    {
        StartCoroutine(DotStart());
    }

    private void Update()
    {
        if (GameManager.gameManager.playerSanity.Sanity <= 0)
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }
    }

    private void OnEnable()
    {
        StartCoroutine(DotStart());
    }

    private void OnDisable()
    {
        StopAllCoroutines();
    }

    private void OnCollisionEnter2D(Collision2D collideInfo)
    {
        if (collideInfo.gameObject.CompareTag("Enemy") && playerGrace == false)
        {
            playerGrace = true;

            PlayerTakesDmg(20);

            for (int i = 1; i < 8; i++)
            {
                Invoke("BlinkOn", i * 0.2f);
                Invoke("BlinkOff", (i * 0.2f) + 0.1f);
            }
        }
    }

    public void PlayerTakesDmg(int dmg)
    {
        CancelInvoke();

        AudioManager.instance.Play("PlayerHit");
        GameManager.gameManager.playerSanity.Sanitydmg(dmg);
        sanityBar.SetSanity(GameManager.gameManager.playerSanity.Sanity);

        InvokeRepeating("PlayerHeal", gracePeriod, healFreq);
    }

    public void PlayerHeal()
    {
        playerGrace = false;

        GameManager.gameManager.playerSanity.Sanityheal(healAmount);
        sanityBar.SetSanity(GameManager.gameManager.playerSanity.Sanity);
    }

    public void PlayerUseStamina(float staminaAmount)
    {
        GameManager.gameManager.playerStamina.useStamina(staminaAmount);
        staminaBar.SetStamina(GameManager.gameManager.playerStamina.Stamina);
    }

    public void PlayerRegenStamina()
    {
        GameManager.gameManager.playerStamina.regenStamina();
        staminaBar.SetStamina(GameManager.gameManager.playerStamina.Stamina);
    }

    void BlinkOn()
    {
        GetComponent<SpriteRenderer>().color = Color.red;
    }

    void BlinkOff()
    {
        GetComponent<SpriteRenderer>().color = Color.white;
    }

    //controls how much damage over how many seconds
    IEnumerator DotActive()
    {
        while (healthDot)
        {
            yield return new WaitForSeconds(dotFreq);
            PlayerTakesDmg(dotDmg);
            for (int i = 1; i < 3; i++)
            {
                Invoke("BlinkOn", i * 0.2f);
                Invoke("BlinkOff", (i * 0.2f) + 0.1f);
            }
        }
    }
    //controls when the dot comes up
    IEnumerator SetActive()
    {
        yield return new WaitForSeconds(dotTimer);
        healthDot = true;
    }

    //activates dot.
    public IEnumerator DotStart()
    {
        yield return StartCoroutine(SetActive());
        yield return StartCoroutine(DotActive());
    }

    public void StartDotCoroutine()
    {
        StartCoroutine(DotStart());
    }
}
