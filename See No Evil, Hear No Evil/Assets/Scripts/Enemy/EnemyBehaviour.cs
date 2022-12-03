using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public static bool stalkerDialoguePlayed = false;

    public float patrolSpeed = 5f;
    public float chaseSpeed = 8f;
    public Pathfinding.AIDestinationSetter pf;
    public Pathfinding.AIPath ap;
    public List<Transform> points = new List<Transform>();
    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public bool patrolling = true;
    public bool isChime = true;
    public Animator animator;
    public DialogueTrigger stalkerDialogue;
    public AudioSource hitSound;
    public AudioSource stalkerSound;

    private int currentPoint = 0;
    private GameObject[] enemies;
    private bool chase = false;
    private GameObject player;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
        player = GameObject.Find("Player");
    }

    private void Start()
    {
        animator.SetBool("Attacking", false);
        animator.SetBool("Walking", true);

        foreach (GameObject enemy in enemies)
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }

        Patrol();
    }

    private void Update()
    {
        if (this.enabled == true && isChime)
        {
            GetComponent<AudioSource>().enabled = true;
        }

        if (player.GetComponent<SenseModes>().visionMode == true && isChime)
        {
            GetComponent<AudioSource>().volume = 0f;
        }
        else if (isChime)
        {
            GetComponent<AudioSource>().volume = 0.4f;
        }

        if (ap.desiredVelocity == Vector3.zero)
        {
            /*if (isChime)
            {
                GetComponent<AudioSource>().Stop();
            }*/

            Invoke("Patrol", 6f);
        }

        if (patrolling == true)
        {
            ap.maxSpeed = patrolSpeed;
        }

        if (patrolling == false)
        {
            pf.target = chaseTarget;
            ap.maxSpeed = chaseSpeed;

            if (isChime && chase == false)
            {
                chase = true;

                if (isChime)
                {
                    GetComponent<AudioSource>().pitch = 2f;
                }
            }
        }
    }

    void ChangePoint()
    {
        if (currentPoint < points.Count - 1 && patrolling)
        {
            currentPoint++;
            pf.target = points[currentPoint];
        }
        else if(patrolling)
        {
            currentPoint = 0;
            pf.target = points[0];
        }
    }

    public void Patrol()
    {
        animator.SetBool("Attacking", false);
        animator.SetBool("Walking", true);

        if (isChime)
        {
            GetComponent<AudioSource>().pitch = 1f;
        }

        chase = false;
        patrolling = true;

        pf.enabled = true;
        pf.target = points[currentPoint];
    }

    private void OnTriggerEnter2D(Collider2D collideInfo)
    {
        if (collideInfo.CompareTag("PatrolPoint") && patrolling == true)
        {
            ChangePoint();
        }
    }

    private void OnCollisionEnter2D(Collision2D collideInfo)
    {
        if (collideInfo.gameObject.CompareTag("Player"))
        {
            hitSound.Play();

            animator.SetBool("Attacking", true);
            animator.SetBool("Walking", false);
            Invoke("OffAni", 0.5f);

            if (isChime)
            {
                GetComponent<AudioSource>().Stop();
            }
            else if (stalkerDialoguePlayed == false)
            {
                stalkerDialoguePlayed = true;
                Invoke("PlayStalkerDialogue", 3f);
                stalkerSound.Play();
            }
            else 
            {
                stalkerSound.Play();
            }

            pf.enabled = false;
            Invoke("Patrol", 8f);
        }
    }

    void OffAni()
    {
        animator.SetBool("Attacking", false);
        animator.SetBool("Walking", false);
    }

    void PlayStalkerDialogue()
    {
        stalkerDialogue.TriggerDialogue();
    }
}
