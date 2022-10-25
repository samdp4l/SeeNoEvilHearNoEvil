using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHearTrigger : MonoBehaviour
{
    public GameObject enemy;

    void OnTriggerEnter2D(Collider2D collideInfo)
    {
        if (collideInfo.gameObject.CompareTag("PlayerSonar") && enemy.GetComponent<EnemyBehaviour>().attacking == false)
        {
            enemy.GetComponent<EnemyBehaviour>().patrolling = false;
            enemy.GetComponent<EnemyBehaviour>().chaseTarget = collideInfo.gameObject.transform;
        }
    }
}
