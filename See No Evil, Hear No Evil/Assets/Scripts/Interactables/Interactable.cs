using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
    public float interactRadius = 2.5f;

    private int collectionValue = 1;

    private void Awake()
    {
        playerTransform = GameObject.Find("Player").transform;
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space))
        {
            //creates a circle collider on a object that detects if player is near by
            Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(playerTransform.position, interactRadius);

            foreach (Collider2D collider2D in collider2DArray)
            {
                InterfaceDoor door = collider2D.GetComponent<InterfaceDoor>();

                if (collider2D.gameObject.CompareTag("Door"))
                {
                    //There is a Door in range
                    door.ToggleDoor();
                }

                if (collider2D.gameObject.CompareTag("TriggerDoor"))
                {
                    //There is a Door in range
                    door.ToggleDoor();
                    EventsManager.instance.PhaseOne();
                }

                if (collider2D.gameObject.CompareTag("Memory"))
                {
                    //collectable.CollectM();
                    InventoryManager.instance.CollectMemory(collectionValue);
                    Destroy(collider2D.gameObject);
                }

                if (collider2D.gameObject.CompareTag("Journal"))
                {
                    //collectable.CollectJ();
                    InventoryManager.instance.CollectJournal(collectionValue);
                    Destroy(collider2D.gameObject);
                }

                if (collider2D.gameObject.CompareTag("Flare"))
                {
                    //collectable.CollectF();
                    InventoryManager.instance.CollectFlare(collectionValue);
                    Destroy(collider2D.gameObject);
                }

                if (collider2D.gameObject.CompareTag("Bottle"))
                {
                    //collectable.CollectB();
                    InventoryManager.instance.CollectBottle(collectionValue);
                    Destroy(collider2D.gameObject);
                }

                if (collider2D.gameObject.CompareTag("Distraction"))
                {
                    collider2D.gameObject.GetComponent<Distraction>().Activate();
                }
            }
        }
    }
}
