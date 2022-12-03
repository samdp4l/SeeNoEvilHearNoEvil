using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialoguePause : MonoBehaviour
{
    public void PauseObject()
    {
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = false;
        }

        GetComponent<SpriteRenderer>().enabled = true;
    }

    public void UnpauseObject()
    {
        MonoBehaviour[] comps = GetComponents<MonoBehaviour>();
        foreach (MonoBehaviour c in comps)
        {
            c.enabled = true;
        }
    }
}
