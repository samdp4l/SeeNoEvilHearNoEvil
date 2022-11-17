using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfViewEnemies : MonoBehaviour
{
    [SerializeField] private EnemyVision enemyVision;
    [SerializeField] private Transform playerLoc;
    [SerializeField] private LayerMask player;
    private Vector3 direction;
    public BlinkingEffect blinkingEffect;
    private Vector3 aimDir;

    private void Update()
    {
        aimDir = (transform.position - playerLoc.position).normalized;
        direction = new Vector3(0, 0, 0);//facing direction

        enemyVision.SetOrigin(transform.position);
        enemyVision.SetAimDirection(direction);

        FindTargetPlayer();
        //Debug.Log(direction);
        

    }

    private void FindTargetPlayer()
    {
        if (Vector3.Distance(transform.position, playerLoc.position) < enemyVision.viewDistance)
        {
            //Debug.Log("Detect player");
            Vector3 dirToPlayer = (playerLoc.position - transform.position).normalized;
            //Debug.Log(dirToPlayer);
            //Debug.Log(playerLoc.position);
            if (Vector3.Angle(dirToPlayer, direction) < enemyVision.fov)
            {
                RaycastHit2D raycastHit2D = Physics2D.Raycast(transform.position, dirToPlayer, enemyVision.viewDistance, player);
                if (raycastHit2D.collider != null)
                {
                    blinkingEffect.hit = true;
                    blinkingEffect.Blink();
                    Debug.Log("Player in fov");
                } 
            }
        }
        else
        {
            blinkingEffect.hit = false;
            blinkingEffect.Blink();
            Debug.Log("Player not in fov");

        }
    }
}
