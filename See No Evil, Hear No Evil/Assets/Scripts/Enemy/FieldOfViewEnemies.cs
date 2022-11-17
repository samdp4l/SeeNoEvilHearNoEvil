using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewEnemies : MonoBehaviour
{
    public EnemyVision enemyVision;
    public Transform enemy;
    public Pathfinding.AIPath ap;

    private Vector3 direction;
    //private Vector3 lookDirection;
    //private float angle;

    private void Update()
    {
        /*lookDirection = (ap.steeringTarget - transform.position).normalized;
        angle = Mathf.Atan2(lookDirection.y, lookDirection.x) * Mathf.Rad2Deg;
        direction = new Vector3(0, 0, angle);*/

        //Debug.Log(direction);
        direction = new Vector3(0f, 0f, enemy.rotation.eulerAngles.z);//facing direction
        //direction = enemy.position;

        enemyVision.SetOrigin(transform.position);
        enemyVision.SetAimDirection(direction);


    }
}
