using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public static EventsManager instance;
    public GameObject player;
    public List<GameObject> enemySpawnpoints = new List<GameObject>();
    public AstarPath grid;
    public AudioSource levelShiftSound;

    public DialogueTrigger wakeUpDialogue;
    public DialogueTrigger closetDialogue;
    public DialogueTrigger firstFragDialogue;
    public DialogueTrigger secondFragDialogue;
    public DialogueTrigger thirdFragDialogue;

    [HideInInspector]
    public int phase = 0;

    private void Awake()
    {
        player = GameObject.Find("Player");

        if (instance == null)
        {
            instance = this;
        }
    }

    private void Start()
    {
        Invoke("WakeUpDialogue", 0.1f);
    }

    private void OnLevelWasLoaded()
    {
        player = GameObject.Find("Player");
        grid = GameObject.Find("A*").GetComponent<AstarPath>();
    }

    /*private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Backspace))
        {
            Scene scene = SceneManager.GetActiveScene();
            SceneManager.LoadScene(scene.name);
        }

        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            PhaseOne();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            PhaseTwo();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            PhaseThree();
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            PhaseFour();
        }
    }*/

    public void PhaseOne()
    {
        if (phase == 0)
        {
            phase = 1;
            levelShiftSound.Play();

            enemySpawnpoints[0].GetComponent<EnemySpawn>().enabled = true;
            //Debug.Log("Phase " + phase);

            closetDialogue.TriggerDialogue();
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(2);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(12);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(13);

            Invoke("RescanGrid", 0.2f);
        }
    }

    public void PhaseTwo()
    {
        if (phase == 1)
        {
            phase = 2;
            levelShiftSound.Play();

            enemySpawnpoints[1].GetComponent<EnemySpawn>().enabled = true;
            //Debug.Log("Phase " + phase);

            CutscenesManager.instance.PlayCutscene1();
            //firstFragDialogue.TriggerDialogue();
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(3);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(14);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(18);

            Invoke("RescanGrid", 0.2f);
        }
    }

    public void PhaseThree()
    {
        if (phase == 2)
        {
            phase = 3;
            levelShiftSound.Play();

            CutscenesManager.instance.PlayCutscene2();
            //secondFragDialogue.TriggerDialogue();
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(4);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(15);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(19);

            //Debug.Log("Phase " + phase);

            Invoke("RescanGrid", 0.2f);
        }
    }

    public void PhaseFour()
    {
        if (phase == 3)
        {
            phase = 4;
            levelShiftSound.Play();

            //Debug.Log("Phase " + phase);

            CutscenesManager.instance.PlayCutscene3();
            //thirdFragDialogue.TriggerDialogue();
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(5);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(16);
            gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(17);

            Invoke("RescanGrid", 0.2f);
        }
    }

    void WakeUpDialogue()
    {
        wakeUpDialogue.TriggerDialogue();
        gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(0);
        gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(6);
        gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(7);
    }

    void RescanGrid()
    {
        grid.Scan();
    }
}
