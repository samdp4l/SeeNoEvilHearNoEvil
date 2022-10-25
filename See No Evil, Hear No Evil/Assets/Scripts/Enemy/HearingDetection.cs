using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HearingDetection : MonoBehaviour
{
    [HideInInspector]
    public bool inRange = false;

    void OnTriggerEnter2D(Collider2D collideInfo)
    {
        if (collideInfo.gameObject.name == "Hearing Range")
        {
            inRange = true;
            Invoke("OnSonarScript", 0.1f);
        }
    }

    void OnTriggerExit2D(Collider2D collideInfo)
    {
        if (collideInfo.gameObject.name == "Hearing Range")
        {
            inRange = false;
            Invoke("OffSonarScript", 0.1f);
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
