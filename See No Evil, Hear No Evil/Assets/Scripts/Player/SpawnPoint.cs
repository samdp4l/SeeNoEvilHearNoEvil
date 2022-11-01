using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnPoint : MonoBehaviour
{
    public List<Transform> spawnPoints = new List<Transform>();
    public int currentSpawn = 0;

    void Start()
    {
        gameObject.transform.position = spawnPoints[currentSpawn].position;
    }
}
