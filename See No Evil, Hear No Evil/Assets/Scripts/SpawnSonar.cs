using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSonar : MonoBehaviour
{
    public Transform spawnPoint;
    public GameObject sonarPrefab;
    public float walkSonarFreq;
    public float runSonarFreq;
    public float enemySonarFreq;
    public bool trigger = true;

    void OnEnable()
    {
        if (gameObject.CompareTag("Enemy") && GetComponent<HearingDetection>().inRange == true)
        {
            InvokeRepeating("SonarSpawn", 0f, enemySonarFreq);
        }
    }

    private void OnDisable()
    {
        CancelInvoke();
    }

    private void Update()
    {
        if (gameObject.CompareTag("Player"))
        {
            if (gameObject.GetComponent<PlayerMovement>().walking == true && trigger == true)
            {
                trigger = false;
                CancelInvoke();
                InvokeRepeating("SonarSpawn", 0f, walkSonarFreq);
            }
            else if (gameObject.GetComponent<PlayerMovement>().running == true && trigger == false)
            {
                trigger = true;
                CancelInvoke();
                InvokeRepeating("SonarSpawn", 0f, runSonarFreq);
            }
            else if (gameObject.GetComponent<PlayerMovement>().sneaking == true || gameObject.GetComponent<PlayerMovement>().moving == false)
            {
                CancelInvoke();
            }
        }

        if (gameObject.CompareTag("Enemy") && GetComponent<HearingDetection>().inRange == false)
        {
            CancelInvoke();
        }
    }

    void SonarSpawn()
    {
        Instantiate(sonarPrefab, spawnPoint.position, spawnPoint.rotation);
    }
}
