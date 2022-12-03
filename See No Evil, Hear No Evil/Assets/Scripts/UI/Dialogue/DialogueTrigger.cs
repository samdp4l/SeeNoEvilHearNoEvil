using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour
{
    public bool playerFirst;
    public bool updateJournal;
    public Dialogue playerDialogue;
    public Dialogue demonDialogue;

    public void TriggerDialogue()
    {
        if (playerFirst == true)
        {
            DialogueManager.instance.playerTalking = true;
        }
        else
        {
            DialogueManager.instance.playerTalking = false;
        }

        DialogueManager.instance.PlayDialogue(playerDialogue, demonDialogue, updateJournal);
    }
}
