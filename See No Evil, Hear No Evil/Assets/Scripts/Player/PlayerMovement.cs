using System.Collections;
using System.Collections.Generic;
//using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float startSpeed = 5f;
    public float runSpeed = 10f;
    public Rigidbody2D rb;

    [HideInInspector]
    public bool scriptOn;

    private float speed;
    private bool stamRegenCD = false;

    private void Start()
    {
        speed = startSpeed;
    }

    private void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
        }
        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
        }
        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
        }

        rb.rotation = GetComponent<LookDir>().angle - 90f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftShift) && GameManager.gameManager.playerStamina.Stamina > 0)
        {
            CancelInvoke("StartStamRegen");
            scriptOn = true;
            stamRegenCD = true;
            speed = runSpeed;
            Invoke("OnSonarScript", 0f);

            GetComponent<StatsManager>().PlayerUseStamina(30f);
        }

        if (stamRegenCD == false)
        {
            GetComponent<StatsManager>().PlayerRegenStamina();
        }

        if ((Input.GetKey(KeyCode.LeftShift) == false || GameManager.gameManager.playerStamina.Stamina <= 0) && stamRegenCD == true)
        {
            scriptOn = false;
            speed = startSpeed;
            Invoke("OffSonarScript", 0.1f);
            Invoke("StartStamRegen", 3f);
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

    void StartStamRegen()
    {
        stamRegenCD = false;
    }
}