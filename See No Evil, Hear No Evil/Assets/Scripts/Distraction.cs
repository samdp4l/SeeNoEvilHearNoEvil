using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    public GameObject sonarPrefab;
    public float spawnFreq = 1.5f;
    public float useCd = 15f;
    public int spawnCount = 5;

    private bool cooldown = false;
    private int currentCount = 0;

    public void Activate()
    {
        if (cooldown == false)
        {
            cooldown = true;
            currentCount = 0;
            InvokeRepeating("SpawnSonar", 0f, spawnFreq);
            Invoke("OffCooldown", useCd);
        }
    }

    void SpawnSonar()
    {
        currentCount += 1;

        if (currentCount < spawnCount + 1)
        {
            Instantiate(sonarPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }
        else
        {
            CancelInvoke("SpawnSonar");
        }
    }

    void OffCooldown()
    {
        cooldown = false;
    }
}
