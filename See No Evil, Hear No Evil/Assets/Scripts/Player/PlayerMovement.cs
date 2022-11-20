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
    public bool moving;
    [HideInInspector]
    public bool walking;
    [HideInInspector]
    public bool running;
    [HideInInspector]
    public bool sneaking;

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
            moving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            moving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
            moving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            moving = true;
        }

        if (Input.anyKey == false)
        {
            moving = false;
        }

        rb.rotation = GetComponent<LookDir>().angle - 90f;
    }

    void FixedUpdate()
    {
         if (Input.GetKey(KeyCode.LeftControl) && moving == true)
        {
            if (sneaking == false)
            {
                walking = false;
                running = false;
                sneaking = true;

                AudioManager.instance.Stop("PlayerWalk");
                AudioManager.instance.Stop("PlayerRun");
            }

            speed = sneakSpeed;

            Invoke("StartStamRegen", 3f);
        }
        else if (Input.GetKey(KeyCode.LeftShift) && GameManager.gameManager.playerStamina.Stamina > 0 && moving == true)
        {
            if (running == false)
            {
                walking = false;
                running = true;
                sneaking = false;

                AudioManager.instance.Stop("PlayerWalk");
                AudioManager.instance.Play("PlayerRun");
            }

            animator.SetBool("Running", true);

            speed = runSpeed;

            stamRegenCD = true;
            CancelInvoke("StartStamRegen");
            gameObject.GetComponent<StatsManager>().PlayerUseStamina(30f);
        }
        else if (moving == true)
        {
            if (walking == false)
            {
                walking = true;
                running = false;
                sneaking = false;

                gameObject.GetComponent<SpawnSonar>().trigger = true;

                AudioManager.instance.Play("PlayerWalk");
                AudioManager.instance.Stop("PlayerRun");
            }

            animator.SetBool("Walking", true);
            speed = startSpeed;

            Invoke("StartStamRegen", 3f);
        }
        else 
        {
            walking = false;
            running = false;
            sneaking = false;

            AudioManager.instance.Stop("PlayerWalk");
            AudioManager.instance.Stop("PlayerRun");

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
