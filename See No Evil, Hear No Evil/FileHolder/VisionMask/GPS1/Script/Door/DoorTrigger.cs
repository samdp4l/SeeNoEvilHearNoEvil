using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorTrigger : MonoBehaviour
{
    [SerializeField] private GameObject doorGameObject;

    private InterfaceDoor door;
    private void Awake()
    {
        door = doorGameObject.GetComponent<InterfaceDoor>();
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            door.OpenDoor();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            door.CloseDoor();
        }
    }
}
