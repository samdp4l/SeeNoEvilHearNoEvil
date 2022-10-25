using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour, InterfaceDoor
{
    public Transform player;
    public bool verticalOpen = true;

    private HingeJoint2D hingeJoint2D;
    private JointAngleLimits2D openDoorLimitsUp;
    private JointAngleLimits2D openDoorLimitsDown;
    private JointAngleLimits2D closeDoorLimits;
    private bool isOpen = false;

    private void Awake()
    {
        player = GameObject.Find("Player").transform;
        hingeJoint2D = transform.Find("Hinge").GetComponent<HingeJoint2D>();

        openDoorLimitsUp = new JointAngleLimits2D { min = -90f, max = -90f };
        openDoorLimitsDown = new JointAngleLimits2D { min = 90f, max = 90f };
        closeDoorLimits = new JointAngleLimits2D { min = 0f, max = 0f };

        CloseDoor();
    }

    public void OpenDoorUp()
    {
        if (isOpen == false)
        {
            isOpen = true;
            hingeJoint2D.limits = openDoorLimitsUp;

            CancelInvoke();
            Invoke("CloseDoor", 5f);
        }
    }

    public void OpenDoorDown()
    {
        if (isOpen == false)
        {
            isOpen = true;
            hingeJoint2D.limits = openDoorLimitsDown;
           
            CancelInvoke();
            Invoke("CloseDoor", 5f);
        }
    }

    public void CloseDoor()
    {
        CancelInvoke();

        isOpen = false;
        hingeJoint2D.limits = closeDoorLimits;
    }

    public void ToggleDoor()
    {
        if (isOpen == false)
        {
            if (verticalOpen == true)
            {
                if (player.position.y < gameObject.transform.position.y)
                {
                    OpenDoorUp();
                }

                if (player.position.y > gameObject.transform.position.y)
                {
                    OpenDoorDown();
                }
            }

            if (verticalOpen == false)
            {
                if (player.position.x > gameObject.transform.position.x)
                {
                    OpenDoorUp();
                }

                if (player.position.x < gameObject.transform.position.x)
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
}
