using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Distraction : MonoBehaviour
{
    public SpriteRenderer tvOn;
    public SpriteRenderer tvOff;
    public GameObject sonarPrefab;

    public float spawnFreq = 1.5f;
    public float useCd = 15f;
    public int spawnCount = 5;

    private bool cooldown = false;
    private int currentCount = 0;
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player.GetComponent<SenseModes>().visionMode == true)
        {
            GetComponent<AudioSource>().volume = 0f;
        }
        else
        {
            GetComponent<AudioSource>().volume = 0.1f;
        }
    }

    public void Activate()
    {
        if (cooldown == false)
        {
            GetComponent<AudioSource>().Play();

            cooldown = true;
            currentCount = 0;

            tvOn.enabled = true;
            tvOff.enabled = false;

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
            GetComponent<AudioSource>().Stop();

            tvOn.enabled = false;
            tvOff.enabled = true;

            CancelInvoke("SpawnSonar");
        }
    }

    void OffCooldown()
    {
        cooldown = false;
    }
}
