using System.Collections;
using System.Collections.Generic;
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

    private void Update()
    {
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
    }

    public void PhaseOne()
    {
        if (phase == 0)
        {
            phase = 1;
            levelShiftSound.Play();

            enemySpawnpoints[0].GetComponent<EnemySpawn>().enabled = true;
            //Debug.Log("Phase " + phase);

            closetDialogue.TriggerDialogue();

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

            firstFragDialogue.TriggerDialogue();

            Invoke("RescanGrid", 0.2f);
        }
    }

    public void PhaseThree()
    {
        if (phase == 2)
        {
            phase = 3;
            levelShiftSound.Play();

            secondFragDialogue.TriggerDialogue();

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

            thirdFragDialogue.TriggerDialogue();

            Invoke("RescanGrid", 0.2f);
        }
    }

    void WakeUpDialogue()
    {
        wakeUpDialogue.TriggerDialogue();
    }

    void RescanGrid()
    {
        grid.Scan();
    }
}
