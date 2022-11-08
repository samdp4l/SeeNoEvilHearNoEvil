using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour, InterfaceDoor
{
    public bool verticalOpen = true;
    public bool locked = false;
    public GameObject door;

    private GameObject player;
    private HingeJoint2D hingeJoint2D;
    private JointAngleLimits2D openDoorLimitsUp;
    private JointAngleLimits2D openDoorLimitsDown;
    private JointAngleLimits2D closeDoorLimits;
    private bool isOpen = false;

    private void Awake()
    {
        player = GameObject.Find("Player");
        hingeJoint2D = transform.Find("Hinge").GetComponent<HingeJoint2D>();

        openDoorLimitsUp = new JointAngleLimits2D { min = -90f, max = -90f };
        openDoorLimitsDown = new JointAngleLimits2D { min = 90f, max = 90f };
        closeDoorLimits = new JointAngleLimits2D { min = 0f, max = 0f };

        CloseDoor();
    }

    public void OpenDoorUp()
    {
        if (isOpen == false && locked == false)
        {
            isOpen = true;
            hingeJoint2D.limits = openDoorLimitsUp;

            CancelInvoke("CloseDoor");
            Invoke("CloseDoor", 5f);

            Physics2D.IgnoreCollision(door.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

            Invoke("EnableCollision", 0.3f);
        }
    }

    public void OpenDoorDown()
    {
        if (isOpen == false && locked == false)
        {
            isOpen = true;
            hingeJoint2D.limits = openDoorLimitsDown;
           
            CancelInvoke("CloseDoor");
            Invoke("CloseDoor", 5f);

            Physics2D.IgnoreCollision(door.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

            Invoke("EnableCollision", 0.3f);
        }
    }

    public void CloseDoor()
    {
        CancelInvoke("CloseDoor");

        isOpen = false;
        hingeJoint2D.limits = closeDoorLimits;
    }

    public void ToggleDoor()
    {
        if (isOpen == false)
        {
            if (verticalOpen == true)
            {
                if (player.transform.position.y < gameObject.transform.position.y)
                {
                    OpenDoorUp();
                }

                if (player.transform.position.y > gameObject.transform.position.y)
                {
                    OpenDoorDown();
                }
            }

            if (verticalOpen == false)
            {
                if (player.transform.position.x > gameObject.transform.position.x)
                {
                    OpenDoorUp();
                }

                if (player.transform.position.x < gameObject.transform.position.x)
                {
                    OpenDoorDown();
                }
            }
        }
        else
        {
            CloseDoor();
        }
    }

    void EnableCollision()
    {
        Physics2D.IgnoreCollision(door.GetComponent<Collider2D>(), player.GetComponent<Collider2D>(), false);
    }
}
