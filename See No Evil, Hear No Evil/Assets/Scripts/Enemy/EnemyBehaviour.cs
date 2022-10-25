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

    private int currentPoint = 0;

    private void Start()
    {
        pf.target = points[0];
    }

    private void Update()
    {
        if (ap.desiredVelocity == Vector3.zero)
        {
            patrolling = true;
            attacking = false;
            pf.target = points[currentPoint];
        }

        if (patrolling == true)
        {
            ap.maxSpeed = patrolSpeed;
        }

        if (patrolling == false)
        {
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
        pf.enabled = true;

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

    private void OnTriggerEnter2D(Collider2D collideInfo)
    {
        if (collideInfo.CompareTag("PatrolPoint"))
        {
            ChangePoint();
        }
    }

    private void OnCollisionEnter2D(Collision2D collideInfo)
    {
        if (collideInfo.gameObject.CompareTag("Player"))
        {
            patrolling = true;
            attacking = false;

            pf.enabled = false;
            Invoke("ChangePoint", 3f);
        }
    }
}
