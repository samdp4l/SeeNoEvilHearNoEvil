using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSonar : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject sonarPrefab;
    public float walkSonarFreq = 1f;
    public float runSonarFreq = 0.3f;
    public float enemySonarFreq = 1f;
    [HideInInspector]
    public bool running = false;

    void OnEnable()
    {
        if (gameObject.CompareTag("Enemy") && GetComponent<HearingDetection>().inRange == true)
        {
            InvokeRepeating("SonarSpawn", 0f, enemySonarFreq);
        }

        if (gameObject.CompareTag("Player"))
        {
            if (running == true)
            {
                CancelInvoke();
                InvokeRepeating("SonarSpawn", 0f, runSonarFreq);
            }
            else if (running == false)
            {
                CancelInvoke();
                InvokeRepeating("SonarSpawn", 0f, walkSonarFreq);
            }
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Update()
    {
        if(gameObject.CompareTag("Enemy") && GetComponent<HearingDetection>().inRange == false)
        {
            CancelInvoke();
        }
    }

    void SonarSpawn()
    {
        Instantiate(sonarPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
