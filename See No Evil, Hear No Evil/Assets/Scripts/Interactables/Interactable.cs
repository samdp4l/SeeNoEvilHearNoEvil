using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    [SerializeField] private Transform playerTransform; 
    public float interactRadius = 2.5f;

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
                if (door != null)
                {
                    //There is a Door in range
                    door.ToggleDoor();
                }
            }
        }
    }
}
