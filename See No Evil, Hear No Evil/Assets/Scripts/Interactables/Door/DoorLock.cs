using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorLock : MonoBehaviour, InterfaceDoor
{
    public static bool firstDoorPlayed = false;

    public bool firstDoor = false;
    public bool closetDoor = false;

    public bool verticalOpen = true;
    public bool locked = false;
    public DialogueTrigger firstDoorDialogue;
    public GameObject door;
    public AudioSource openSound;
    public AudioSource closeSound;
    public AudioSource lockedSound;

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

        isOpen = false;
        hingeJoint2D.limits = closeDoorLimits;
    }

    private void Update()
    {
        if (player.GetComponent<SenseModes>().visionMode == true)
        {
            openSound.volume = 0f;
            closeSound.volume = 0f;
        }
        else
        {
            openSound.volume = 0.5f;
            closeSound.volume = 0.5f;
        }
    }

    public void OpenDoorUp()
    {
        if (isOpen == false && locked == false)
        {
            isOpen = true;
            hingeJoint2D.limits = openDoorLimitsUp;
            openSound.Play();

            if (firstDoor == false && closetDoor == false)
            {
                CancelInvoke("CloseDoor");
                Invoke("CloseDoor", 5f);
            }
            else if (firstDoor == true && firstDoorPlayed == false)
            {
                firstDoor = false;
                firstDoorPlayed = true;
                firstDoorDialogue.TriggerDialogue();
                gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(1);
                gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(10);
                gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(11);
            }
            else if (closetDoor == true)
            {
                closetDoor = false;
            }


            Physics2D.IgnoreCollision(door.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

            Invoke("EnableCollision", 0.3f);
        }
        else if (locked == true)
        {
            lockedSound.Play();
        }
    }

    public void OpenDoorDown()
    {
        if (isOpen == false && locked == false)
        {
            isOpen = true;
            hingeJoint2D.limits = openDoorLimitsDown;
            openSound.Play();

            if (firstDoor == false && closetDoor == false)
            {
                CancelInvoke("CloseDoor");
                Invoke("CloseDoor", 5f);
            }
            else if (firstDoor == true && firstDoorPlayed == false)
            {
                firstDoor = false;
                firstDoorPlayed = true;
                firstDoorDialogue.TriggerDialogue();
                gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(1);
                gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(10);
                gameObject.GetComponent<UnlockEntry>().TriggerJournalEntry(11);
            }
            else if (closetDoor == true)
            {
                closetDoor = false;
            }

            Physics2D.IgnoreCollision(door.GetComponent<Collider2D>(), player.GetComponent<Collider2D>());

            Invoke("EnableCollision", 0.3f);
        }
        else if (locked == true)
        {
            lockedSound.Play();
        }
    }

    public void CloseDoor()
    {
        closeSound.Play();

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
