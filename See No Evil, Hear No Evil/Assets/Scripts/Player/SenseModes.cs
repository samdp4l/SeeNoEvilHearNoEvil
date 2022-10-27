using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SenseModes : MonoBehaviour
{
    public float senseTimer = 15f;
    [HideInInspector]
    public bool visionMode = true;

    private GameObject viewing;
    private GameObject viewingCircle;
    private GameObject hearing;

    private void Awake()
    {
        viewing = GameObject.Find("Field of View");
        viewingCircle = GameObject.Find("Field of View Circle");
        hearing = GameObject.Find("Hearing Range");
    }

    private void Start()
    {
        hearing.SetActive(false);
        InvokeRepeating("Countdown", 1f, 1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            CancelInvoke();
            senseTimer = 15f;
            viewing.GetComponent<FieldOfView>().fov = 90f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 3f;
            hearing.transform.localScale = new Vector3(30f, 30f);

            GetComponent<StatsManager>().StopAllCoroutines();
            GetComponent<StatsManager>().healthDot = false;
            GetComponent<StatsManager>().StartDotCoroutine();

            InvokeRepeating("Countdown", 1f, 1f);

            if (visionMode == true)
            {
                visionMode = false;
                viewing.SetActive(false);
                hearing.SetActive(true);
            }
            else if (visionMode == false)
            {
                visionMode = true;
                hearing.SetActive(false);
                viewing.SetActive(true);
            }
        }
    }

    void Countdown()
    {
        senseTimer -= 1;

        if (senseTimer <= 0f)
        {
            viewing.GetComponent<FieldOfView>().fov = 10f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 1.5f;
            hearing.transform.localScale = new Vector3(15f, 15f);
        }
        else if (senseTimer <= 5f)
        {
            viewing.GetComponent<FieldOfView>().fov = 30f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 2f;
            hearing.transform.localScale = new Vector3(20f, 20f);
        }
        else if (senseTimer <= 10f)
        {
            viewing.GetComponent<FieldOfView>().fov = 60f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 2.5f;
            hearing.transform.localScale = new Vector3(25f, 25f);
        }
    }
}
