using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutscenesManager : MonoBehaviour
{
    public static CutscenesManager instance;

    public GameObject cutscene1;
    public GameObject cutscene2;
    public GameObject cutscene3;
    public DialogueTrigger firstFragDialogue;
    public DialogueTrigger secondFragDialogue;
    public DialogueTrigger thirdFragDialogue;

    private GameObject player;
    private GameObject[] enemies;

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
    }

    public void PlayCutscene1()
    {
        DisableCharacters();
        cutscene1.SetActive(true);
        Invoke("Cutscene1End", 15f);
    }

    public void PlayCutscene2()
    {
        DisableCharacters();
        cutscene2.SetActive(true);
        Invoke("Cutscene2End", 11f);
    }

    public void PlayCutscene3()
    {
        DisableCharacters();
        cutscene3.SetActive(true);
        Invoke("Cutscene3End", 22f);
    }

    void Cutscene1End()
    {
        cutscene1.SetActive(false);
        firstFragDialogue.TriggerDialogue();
    }

    void Cutscene2End()
    {
        cutscene2.SetActive(false);
        secondFragDialogue.TriggerDialogue();
    }

    void Cutscene3End()
    {
        cutscene3.SetActive(false);
        thirdFragDialogue.TriggerDialogue();
    }

    void DisableCharacters()
    {
        player = GameObject.Find("Player");
        enemies = GameObject.FindGameObjectsWithTag("Enemy");

        player.GetComponent<DialoguePause>().PauseObject();

        foreach (GameObject e in enemies)
        {
            e.GetComponent<DialoguePause>().PauseObject();
        }
    }
}
