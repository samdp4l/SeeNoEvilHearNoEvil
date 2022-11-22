using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewEnemies : MonoBehaviour
{
    public EnemyVision enemyVision;
    public Transform enemy;
    public Pathfinding.AIPath ap;

    private Vector3 direction;

    private void Update()
    {
        direction = new Vector3(0f, 0f, enemy.rotation.eulerAngles.z);

        enemyVision.SetOrigin(transform.position);
        enemyVision.SetAimDirection(direction);
    }
}
