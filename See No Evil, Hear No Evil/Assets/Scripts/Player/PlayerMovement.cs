using System.Collections;
using System.Collections.Generic;
//using Cinemachine;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static bool movementDialoguePlayed = false;

    public float startSpeed = 5f;
    public float runSpeed = 10f;
    public float sneakSpeed = 2f;
    public Rigidbody2D rb;
    public Animator animator;
    public DialogueTrigger movementDialogue;
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
        if((Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.D)) && movementDialoguePlayed == false)
        {
            movementDialoguePlayed = true;
            movementDialogue.TriggerDialogue();
        }

        if (Input.GetKey(KeyCode.W))
        {
            animator.SetBool("Moving", true);

            transform.position += new Vector3(0f, speed * Time.deltaTime, 0f);
            moving = true;
        }

        if (Input.GetKey(KeyCode.A))
        {
            animator.SetBool("Moving", true);

            transform.position += new Vector3(-speed * Time.deltaTime, 0f, 0f);
            moving = true;
        }

        if (Input.GetKey(KeyCode.S))
        {
            animator.SetBool("Moving", true);

            transform.position += new Vector3(0f, -speed * Time.deltaTime, 0f);
            moving = true;
        }

        if (Input.GetKey(KeyCode.D))
        {
            animator.SetBool("Moving", true);

            transform.position += new Vector3(speed * Time.deltaTime, 0f, 0f);
            moving = true;
        }

        if (Input.anyKey == false)
        {
            animator.SetBool("Moving", false);
            animator.SetBool("Walking", false);
            animator.SetBool("Sprinting", false);

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
                animator.SetBool("Walking", true);
                animator.SetBool("Sprinting", false);

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
                animator.SetBool("Walking", false);
                animator.SetBool("Sprinting", true);

                walking = false;
                running = true;
                sneaking = false;

                AudioManager.instance.Stop("PlayerWalk");
                AudioManager.instance.Play("PlayerRun");
            }

            speed = runSpeed;

            stamRegenCD = true;
            CancelInvoke("StartStamRegen");
            gameObject.GetComponent<StatsManager>().PlayerUseStamina(30f);
        }
        else if (moving == true)
        {
            animator.SetBool("Walking", true);
            animator.SetBool("Sprinting", false);

            if (walking == false)
            {
                walking = true;
                running = false;
                sneaking = false;

                gameObject.GetComponent<SpawnSonar>().trigger = true;

                AudioManager.instance.Play("PlayerWalk");
                AudioManager.instance.Stop("PlayerRun");
            }

            speed = startSpeed;

            Invoke("StartStamRegen", 3f);
        }
        else 
        {
            animator.SetBool("Moving", false);
            animator.SetBool("Walking", false);
            animator.SetBool("Sprinting", false);

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
