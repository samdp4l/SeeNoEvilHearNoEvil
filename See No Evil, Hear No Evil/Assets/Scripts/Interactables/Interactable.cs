using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
    public float interactRadius = 2.5f;
    public Animator animator;

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
                InterfaceHiding hiding = collider2D.GetComponent<InterfaceHiding>();

                if(collider2D.gameObject != null)
                {
                    animator.SetBool("Interact", true);
                    Invoke("OffAni", 0.3f);
                }

                if (collider2D.gameObject.CompareTag("Door"))
                {
                    door.ToggleDoor();
                }

                if (collider2D.gameObject.CompareTag("TriggerDoor"))
                {
                    door.ToggleDoor();
                    EventsManager.instance.PhaseOne();
                }

                if (collider2D.gameObject.CompareTag("Memory"))
                {
                    InventoryManager.instance.CollectMemory(collectionValue);
                    Destroy(collider2D.gameObject);
                }

                if (collider2D.gameObject.CompareTag("Journal"))
                {
                    AudioManager.instance.Play("WriteJournal");
                    InventoryManager.instance.CollectJournal(collectionValue);
                    Destroy(collider2D.gameObject);
                }

                if (collider2D.gameObject.CompareTag("Glowstick"))
                {
                    if (InventoryManager.instance.glowstickCount < InventoryManager.instance.throwableLimit)
                    {
                        InventoryManager.instance.CollectGlowstick(collectionValue);
                        Destroy(collider2D.gameObject);
                    }
                    else
                    {
                        Debug.Log("Can't carry anymore glowsticks");
                    }
                }

                if (collider2D.gameObject.CompareTag("Bottle"))
                {
                    if (InventoryManager.instance.bottleCount < InventoryManager.instance.throwableLimit)
                    {
                        InventoryManager.instance.CollectBottle(collectionValue);
                        Destroy(collider2D.gameObject);
                    }
                    else
                    {
                        Debug.Log("Can't carry anymore bottles");
                    }
                }

                if (collider2D.gameObject.CompareTag("Distraction"))
                {
                    collider2D.gameObject.GetComponent<Distraction>().Activate();
                }

                if (collider2D.gameObject.CompareTag("HidingSpot"))
                {
                    hiding.toggleIsHiding();
                }
            }
        }
    }

    void OffAni()
    {
        animator.SetBool("Interact", false);
    }
}
