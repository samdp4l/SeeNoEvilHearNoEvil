using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSonar : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject sonarPrefab;

    void OnEnable()
    {
        if (gameObject.CompareTag("Enemy") && GetComponent<HearingDetection>().inRange == true)
        {
            InvokeRepeating("spawnSonar", 0.5f, 0.7f);
        }

        if (gameObject.CompareTag("Player") && GetComponent<PlayerMovement>().scriptOn == true)
        {
            InvokeRepeating("spawnSonar", 0f, 0.3f);
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

    void spawnSonar()
    {
        Instantiate(sonarPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
