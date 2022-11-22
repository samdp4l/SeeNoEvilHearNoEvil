using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public TextMeshProUGUI text;
    public int throwableLimit = 2;
    [HideInInspector]
    public int journalCollection = 0;
    [HideInInspector]
    public int glowstickCount = 0;
    [HideInInspector]
    public int bottleCount = 0;

    private int memoryCollection = 0;

    void Start()
    {
        if (instance == null)
        {
            instance = this;
        }
    }

    public void CollectMemory(int collectionValue)
    {
        memoryCollection += collectionValue;
        //Debug.Log("Memory: " + memoryCollection);

        if (memoryCollection == 1)
        {
            EventsManager.instance.PhaseTwo();
        }
        if (memoryCollection == 2)
        {
            EventsManager.instance.PhaseThree();
        }
    }

    public void CollectJournal(int collectionValue)
    {
        journalCollection += collectionValue;
        //Debug.Log("Journal: " +journalCollection);
    }

    public void CollectGlowstick(int collectionValue)
    {
        glowstickCount += collectionValue;
        //Debug.Log("Glowstick: " + glowstickCount);
    }

    public void CollectBottle(int collectionValue)
    {
        bottleCount += collectionValue;
        //Debug.Log("Bottle: " + bottleCount);
    }
}
