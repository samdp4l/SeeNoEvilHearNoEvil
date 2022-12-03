using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnlockEntry : MonoBehaviour
{
    public int noteNo;

    public void TriggerJournalEntry(int e)
    {
        PauseMenu.instance.UpdateJournal(e);
    }

    public void TriggerNoteEntry()
    {
        PauseMenu.instance.UpdateJournal(noteNo);
    }
}
