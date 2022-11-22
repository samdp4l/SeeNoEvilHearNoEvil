using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttackTrigger : MonoBehaviour
{
    public GameObject enemy;

    void OnTriggerEnter2D(Collider2D collideInfo)
    {
        if (collideInfo.gameObject.CompareTag("Player"))
        {
            enemy.GetComponent<EnemyBehaviour>().patrolling = false;
            enemy.GetComponent<EnemyBehaviour>().chaseTarget = collideInfo.gameObject.transform;

            Invoke("StopChase", 5f);
        }
    }

    void StopChase()
    {
        enemy.GetComponent<EnemyBehaviour>().patrolling = true;
        enemy.GetComponent<EnemyBehaviour>().Patrol();
    }
}
