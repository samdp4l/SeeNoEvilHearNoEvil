using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public int currentSpawn = 0;

    void Start()
    {
        if (EventsManager.instance.phase == 0)
        {
            currentSpawn = 0;
        }
        else if (EventsManager.instance.phase == 1)
        {
            currentSpawn = 1;
        }
        else if (EventsManager.instance.phase == 2)
        {
            currentSpawn = 2;
        }
        else if (EventsManager.instance.phase == 3)
        {
            currentSpawn = 3;
        }

        gameObject.transform.position = spawnPoints[currentSpawn].position;
    }
}
