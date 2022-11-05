using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewEnemies : MonoBehaviour
{
    [SerializeField] private EnemyVision enemyVision;
    private Vector3 direction;

    private void Update()
    {
        direction = new Vector3(0, 0, 1f);//facing direction

        enemyVision.SetOrigin(transform.position);
        enemyVision.SetAimDirection(direction);
    }
}
