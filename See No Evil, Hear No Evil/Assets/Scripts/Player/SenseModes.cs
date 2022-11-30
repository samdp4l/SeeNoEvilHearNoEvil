using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SenseModes : MonoBehaviour
{
    public float senseTimer = 60f;
    public float totalCooldown = 5f;
    [HideInInspector]
    public bool visionMode = true;

    private bool senseCD;
    private GameObject viewing;
    private GameObject viewingCircle;
    private GameObject hearingRange;
    private GameObject eyeIcon;
    private GameObject earIcon;
    private GameObject cooldownText;
    private float currentCooldown;

    private void Awake()
    {
        viewing = GameObject.Find("Field of View");
        viewingCircle = GameObject.Find("Field of View Circle");
        hearingRange = GameObject.Find("Hearing Range");
        eyeIcon = GameObject.Find("Eye Icon");
        earIcon = GameObject.Find("Ear Icon");
        cooldownText = GameObject.Find("Sense CD");
    }

    private void Start()
    {
        currentCooldown = totalCooldown;
        cooldownText.SetActive(false);

        hearingRange.SetActive(false);
        earIcon.SetActive(false);

        InvokeRepeating("Countdown", 1f, 1f);
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && senseCD == false)
        {
            senseCD = true;
            InvokeRepeating("OffCooldown", 1f, 1f);

            cooldownText.SetActive(true);

            CancelInvoke("Countdown");
            senseTimer = 60f;
            viewing.GetComponent<FieldOfView>().fov = 90f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 2f;

            GetComponent<StatsManager>().StopAllCoroutines();
            GetComponent<StatsManager>().healthDot = false;
            GetComponent<StatsManager>().StartDotCoroutine();

            InvokeRepeating("Countdown", 1f, 1f);

            if (visionMode == true)
            {
                visionMode = false;

                viewing.SetActive(false);
                hearingRange.SetActive(true);

                eyeIcon.SetActive(false);
                earIcon.SetActive(true);
            }
            else if (visionMode == false)
            {
                visionMode = true;

                hearingRange.SetActive(false);
                viewing.SetActive(true);

                earIcon.SetActive(false);
                eyeIcon.SetActive(true);
            }
        }

        if (senseCD == true)
        {
            cooldownText.GetComponent<TextMeshProUGUI>().text = currentCooldown.ToString();
        }
    }

    private void OnEnable()
    {
        InvokeRepeating("Countdown", 1f, 1f);
    }

    private void OnDisable()
    {
        CancelInvoke("Countdown");
    }

    void Countdown()
    {
        senseTimer -= 1;

        if (senseTimer <= 5f)
        {
            viewing.GetComponent<FieldOfView>().fov = 10f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 1.25f;
        }
        else if (senseTimer <= 20f)
        {
            viewing.GetComponent<FieldOfView>().fov = 30f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 1.5f;
        }
        else if (senseTimer <= 40f)
        {
            viewing.GetComponent<FieldOfView>().fov = 60f;
            viewingCircle.GetComponent<FieldOfViewCircle>().viewDistance = 1.75f;
        }
    }

    void OffCooldown()
    {
        currentCooldown -= 1f;

        if (currentCooldown <= 0f)
        {
            senseCD = false;
            CancelInvoke("OffCooldown");
            cooldownText.SetActive(false);
            currentCooldown = totalCooldown;
        }
    }
}
