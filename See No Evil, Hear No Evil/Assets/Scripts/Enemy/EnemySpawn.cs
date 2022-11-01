using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public GameObject enemyPrefab;
    public List<Transform> patrolPoints = new List<Transform>();

    private GameObject thisEnemy;

    private void OnEnable()
    {
        thisEnemy = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);
        Invoke("AssignPatrolRoute", 0.2f);
    }

    public void AssignPatrolRoute()
    {
        thisEnemy.GetComponent<EnemyBehaviour>().points = patrolPoints;
    }
}
