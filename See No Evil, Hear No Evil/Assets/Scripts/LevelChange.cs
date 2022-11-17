using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelChange : MonoBehaviour
{
    private void Update()
    {
        if (EventsManager.instance.phase == 1)
        {
            UnlockOne();
        }

        if (EventsManager.instance.phase == 2)
        {
            UnlockTwo();
        }

        if (EventsManager.instance.phase == 3)
        {
            UnlockThree();
        }

        if (EventsManager.instance.phase == 4)
        {
            UnlockFour();
        }
    }


    void UnlockOne()
    {
        if (gameObject == GameObject.Find("Locked Door 1A") || gameObject == GameObject.Find("Locked Door 1B"))
        {
            gameObject.GetComponent<DoorLock>().locked = false;
        }

        if (gameObject.CompareTag("Wall1"))
        {
            Destroy(gameObject);
        }
    }

    void UnlockTwo()
    {
        if (gameObject == GameObject.Find("Locked Door 2A") || gameObject == GameObject.Find("Locked Door 2B"))
        {
            gameObject.GetComponent<DoorLock>().locked = false;
        }

        if (gameObject.CompareTag("Wall2"))
        {
            Destroy(gameObject);
        }
    }

    void UnlockThree()
    {
        if (gameObject == GameObject.Find("Locked Door 3A") || gameObject == GameObject.Find("Locked Door 3B"))
        {
            gameObject.GetComponent<DoorLock>().locked = false;
        }

        if (gameObject.CompareTag("Wall3"))
        {
            Destroy(gameObject);
        }
    }

    void UnlockFour()
    {
        if (gameObject == GameObject.Find("Basement Door"))
        {
            gameObject.GetComponent<DoorLock>().locked = false;
        }
    }
}
