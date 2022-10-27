using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class InventoryManager : MonoBehaviour
{
    public static InventoryManager instance;
    public TextMeshProUGUI text;
    public int throwableLimit = 2;
    int memoryCollection = 0;
    int journalCollection = 0;
    int flareCount = 0;
    int bottleCount = 0;

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
