using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int collectionValue = 1;

    public void CollectM()
    {
        InventoryManager.instance.CollectMemory(collectionValue);
    }

    public void CollectJ()
    {
        InventoryManager.instance.CollectJournal(collectionValue);
    }

    public void CollectG()
    {
        InventoryManager.instance.CollectGlowstick(collectionValue);
    }

    public void CollectB()
    {
        InventoryManager.instance.CollectBottle(collectionValue);
    }
}
