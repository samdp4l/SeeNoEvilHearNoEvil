using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBehaviour : MonoBehaviour
{
    public float patrolSpeed = 5f;
    public float chaseSpeed = 8f;
    public float attackSpeed = 12f;
    public Pathfinding.AIDestinationSetter pf;
    public Pathfinding.AIPath ap;
    public List<Transform> points = new List<Transform>();
    [HideInInspector]
    public Transform chaseTarget;
    [HideInInspector]
    public bool patrolling = true;
    [HideInInspector]
    public bool attacking = false;
    public bool isChime = true;

    private int currentPoint = 0;
    private GameObject[] enemies;
    private bool reset = false;
    private bool chase = false;

    private void Awake()
    {
        enemies = GameObject.FindGameObjectsWithTag("Enemy");
    }

    private void Start()
    {
        foreach (GameObject enemy in enemies)
        {
            Physics2D.IgnoreCollision(enemy.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
        if (isChime)
        {
            AudioManager.instance.Play("ChimeWalk");
        }
    }

    private void Update()
    {
        if (ap.desiredVelocity == Vector3.zero && reset == false)
        {
            if (isChime)
            {
                AudioManager.instance.Stop("ChimeWalk");
                AudioManager.instance.Stop("ChimeChase");
                reset = true;
            }
            Invoke("Patrol", 3f);
        }

        if (patrolling == true)
        {
            ap.maxSpeed = patrolSpeed;
        }

        if (patrolling == false)
        {
            if (isChime && chase == false)
            {
                chase = true;
                AudioManager.instance.Stop("ChimeWalk");
                AudioManager.instance.Play("ChimeChase");
            }

            pf.target = chaseTarget;

            if (attacking == false)
            {
                ap.maxSpeed = chaseSpeed;
            }

            if (attacking == true)
            {
                ap.maxSpeed = attackSpeed;
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
        if (isChime)
        {
            AudioManager.instance.Play("ChimeWalk");
            AudioManager.instance.Stop("ChimeChase");
        }
        reset = false;
        chase = false;
        patrolling = true;
        attacking = false;

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
            if (isChime)
            {
                AudioManager.instance.Stop("ChimeWalk");
                AudioManager.instance.Stop("ChimeChase");
            }
            pf.enabled = false;
            Invoke("Patrol", 3f);
        }
    }
}
