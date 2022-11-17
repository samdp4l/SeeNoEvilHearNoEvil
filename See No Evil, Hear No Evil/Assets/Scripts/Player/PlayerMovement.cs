using System.Collections;
using System.Collections.Generic;
//using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float startSpeed = 5f;
    public float runSpeed = 10f;
    public float sneakSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;
    [HideInInspector]
    public bool walking;

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

        if (walking == false && (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)))
        {
            AudioManager.instance.Play("PlayerWalk");
            animator.SetBool("Walking", true);
            walking = true;
        }

        else if (Input.anyKey == false)
        {
            AudioManager.instance.Stop("PlayerWalk");
            animator.SetBool("Walking", false);
            walking = false;
        }

        rb.rotation = GetComponent<LookDir>().angle - 90f;
    }

    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.LeftControl))
        {
            AudioManager.instance.Stop("PlayerWalk");
            AudioManager.instance.Stop("PlayerRun");
            GetComponent<SpawnSonar>().enabled = false;
            speed = sneakSpeed;
            Invoke("StartStamRegen", 3f);
        }

        else if (Input.GetKeyDown(KeyCode.LeftShift) && GameManager.gameManager.playerStamina.Stamina > 0 && GetComponent<SpawnSonar>().running == false)
        {
            animator.SetBool("Running", true);
            AudioManager.instance.Stop("PlayerWalk");
            AudioManager.instance.Play("PlayerRun");
            GetComponent<SpawnSonar>().running = true;
            GetComponent<SpawnSonar>().enabled = false;
            GetComponent<SpawnSonar>().enabled = true;
        }

        else if ((Input.GetKeyUp(KeyCode.LeftShift) || GameManager.gameManager.playerStamina.Stamina <= 0) && GetComponent<SpawnSonar>().running == true)
        {
            animator.SetBool("Running", false);
            AudioManager.instance.Play("PlayerWalk");
            AudioManager.instance.Stop("PlayerRun");
            GetComponent<SpawnSonar>().running = false;
            GetComponent<SpawnSonar>().enabled = false;
            GetComponent<SpawnSonar>().enabled = true;
        }

        else if (Input.GetKey(KeyCode.LeftShift) && GameManager.gameManager.playerStamina.Stamina > 0)
        {
            CancelInvoke("StartStamRegen");
            stamRegenCD = true;
            speed = runSpeed;

            GetComponent<StatsManager>().PlayerUseStamina(30f);
        }

        else if (walking == true)
        {
            speed = startSpeed;
            GetComponent<SpawnSonar>().enabled = true;
            Invoke("StartStamRegen", 3f);
        }

        else if (walking == false)
        {
            AudioManager.instance.Stop("PlayerWalk");
            AudioManager.instance.Stop("PlayerRun");
            GetComponent<SpawnSonar>().enabled = false;
            Invoke("StartStamRegen", 3f);
        }

        if (stamRegenCD == false)
        {
            GetComponent<StatsManager>().PlayerRegenStamina();
        }
    }

    void StartStamRegen()
    {
        stamRegenCD = false;
    }
}
