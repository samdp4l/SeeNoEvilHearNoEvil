using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Interactable : MonoBehaviour
{
    public static bool journalDialoguePlayed = false;
    public static bool bottleDialoguePlayed = false;
    public static bool glowstickDialoguePlayed = false;
    public static bool tvDialoguePlayed = false;
    public static bool closetDialoguePlayed = false;

    public Material normalMat;
    public Material highlightMat;
    public DialogueTrigger journalDialogue;
    public DialogueTrigger bottleDialogue;
    public DialogueTrigger glowstickDialogue;
    public DialogueTrigger tvDialogue;
    public DialogueTrigger closetDialogue;

    private float interactRadius = 1.5f;

    void Update()
    {
        Collider2D[] collider2DArray = Physics2D.OverlapCircleAll(gameObject.transform.position, interactRadius, 8192);

        if (collider2DArray == null || collider2DArray.Length == 0)
        {
            gameObject.GetComponent<Renderer>().material = normalMat;
        }
        else
        {
            gameObject.GetComponent<Renderer>().material = highlightMat;

            if (gameObject.CompareTag("Journal") && journalDialoguePlayed == false)
            {
                journalDialoguePlayed = true;
                journalDialogue.TriggerDialogue();
            }

            if (gameObject.CompareTag("Bottle") && bottleDialoguePlayed == false)
            {
                bottleDialoguePlayed = true;
                bottleDialogue.TriggerDialogue();
            }

            if (gameObject.CompareTag("Glowstick") && glowstickDialoguePlayed == false)
            {
                glowstickDialoguePlayed = true;
                glowstickDialogue.TriggerDialogue();
            }

            if (gameObject.CompareTag("Distraction") && tvDialoguePlayed == false)
            {
                tvDialoguePlayed = true;
                tvDialogue.TriggerDialogue();
            }

            if (gameObject.CompareTag("HidingSpot") && closetDialoguePlayed == false)
            {
                closetDialoguePlayed = true;
                closetDialogue.TriggerDialogue();
            }
        }
    }
}
