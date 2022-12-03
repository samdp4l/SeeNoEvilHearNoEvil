using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingDetection : MonoBehaviour
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    private void Update()
    {
        if (player.GetComponent<SenseModes>().visionMode)
        {
            OffSonarScript();
        }
        else
        {
            OnSonarScript();
        }
    }

    void OnSonarScript()
    {
        GetComponent<SpawnSonar>().enabled = true;
    }

    void OffSonarScript()
    {
        GetComponent<SpawnSonar>().enabled = false;
    }
}
