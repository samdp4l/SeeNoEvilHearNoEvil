using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDoor : MonoBehaviour
{
    public Transform enemy;
    public float interactRadius = 5f;
    private GameObject[] doors;

    private void Awake()
    {
        doors = GameObject.FindGameObjectsWithTag("Door");
    }

    private void Start()
    {
        foreach (GameObject door in doors)
        {
            Physics2D.IgnoreCollision(door.GetComponent<Collider2D>(), gameObject.GetComponent<Collider2D>());
        }
    }

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
