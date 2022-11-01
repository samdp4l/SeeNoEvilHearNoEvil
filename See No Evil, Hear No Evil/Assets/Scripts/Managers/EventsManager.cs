using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EventsManager : MonoBehaviour
{
    public GameObject player;
    public static EventsManager instance;
    public List<GameObject> enemySpawnpoints = new List<GameObject>();
    public AstarPath grid;

    [HideInInspector]
    public int phase = 0;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void PhaseOne()
    {
        if (phase == 0)
        {
            phase = 1;
            player.GetComponent<SpawnPoint>().currentSpawn += 1;

            enemySpawnpoints[0].GetComponent<EnemySpawn>().enabled = true;
            Debug.Log("Phase " + phase);

            Invoke("RescanGrid", 0.2f);
        }
    }

    public void PhaseTwo()
    {
        if (phase == 1)
        {
            phase = 2;
            player.GetComponent<SpawnPoint>().currentSpawn += 1;

            enemySpawnpoints[1].GetComponent<EnemySpawn>().enabled = true;
            Debug.Log("Phase " + phase);

            Invoke("RescanGrid", 0.2f);
        }
    }

    public void PhaseThree()
    {
        if (phase == 2)
        {
            phase = 3;
            player.GetComponent<SpawnPoint>().currentSpawn += 1;

            enemySpawnpoints[2].GetComponent<EnemySpawn>().enabled = true;
            Debug.Log("Phase " + phase);

            Invoke("RescanGrid", 0.2f);
        }
    }

    public void PhaseFour()
    {
        if (phase == 3)
        {
            phase = 4;
            player.GetComponent<SpawnPoint>().currentSpawn += 1;

            Debug.Log("Phase " + phase);

            Invoke("RescanGrid", 0.2f);
        }
    }

    void RescanGrid()
    {
        grid.Scan();
    }
}
