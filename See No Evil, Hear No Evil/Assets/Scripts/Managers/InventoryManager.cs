using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public TextMeshProUGUI text;
    public int throwableLimit = 2;
    public int journalCollection = 0;
    public int flareCount = 0;
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
        //text.text = "X" + collection.ToString();
        Debug.Log("Memory: " + memoryCollection);

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
        Debug.Log("Journal: " +journalCollection);
    }

    public void CollectFlare(int collectionValue)
    {
        if (flareCount < throwableLimit)
        {
            flareCount += collectionValue;
            Debug.Log("Flare: " + flareCount);
        }
        else 
        {
            Debug.Log("Can't carry anymore flares");
        }
    }

    public void CollectBottle(int collectionValue)
    {
        if (bottleCount < throwableLimit)
        {
            bottleCount += collectionValue;
            Debug.Log("Bottle: " + bottleCount);
        }
        else
        {
            Debug.Log("Can't carry anymore bottles");
        }
    }
}
