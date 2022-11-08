using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawn : MonoBehaviour
{
    public bool isChime = true;
    public GameObject enemyPrefab;
    public GameObject visionPrefab;
    public List<Transform> patrolPoints = new List<Transform>();

    private GameObject thisEnemy;
    private GameObject thisVision;

    private void OnEnable()
    {
        thisEnemy = Instantiate(enemyPrefab, gameObject.transform.position, gameObject.transform.rotation);

        if (isChime)
        {
            thisVision = Instantiate(visionPrefab, gameObject.transform.position, gameObject.transform.rotation);
        }

        Invoke("AssignReferences", 0.2f);
    }

    public void AssignReferences()
    {
        thisEnemy.GetComponent<EnemyBehaviour>().points = patrolPoints;

        if (isChime)
        {
            thisEnemy.GetComponent<FieldOfViewEnemies>().enemyVision = thisVision.GetComponent<EnemyVision>();
            thisVision.GetComponent<EnemyVision>().enemy = thisEnemy;
        }
    }
}
