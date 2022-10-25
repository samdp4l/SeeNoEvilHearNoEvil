using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    public Transform enemy;
    public float interactRadius = 5f;

    // Update is called once per frame
    void Update()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(enemy.position, interactRadius);

        foreach (Collider2D collider2D in collider2DArray)
        {
            InterfaceDoor door = collider2D.GetComponent<InterfaceDoor>();
            if (door != null)
            {
                if (collider2D.GetComponent<DoorLock>().verticalOpen == true)
                {
                    if (enemy.position.y < collider2D.transform.position.y)
                    {
                        door.OpenDoorUp();
                    }

                    if (enemy.position.y > collider2D.transform.position.y)
                    {
                        door.OpenDoorDown();
                    }
                }

                if (collider2D.GetComponent<DoorLock>().verticalOpen == false)
                {
                    if (enemy.position.x > collider2D.transform.position.x)
                    {
                        door.OpenDoorUp();
                    }

                    if (enemy.position.x < collider2D.transform.position.x)
                    {
                        door.OpenDoorDown();
                    }
                }
            }
        }
    }
}
