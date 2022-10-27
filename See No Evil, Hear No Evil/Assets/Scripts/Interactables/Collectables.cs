using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collectables : MonoBehaviour
{
    public int collectionValue = 1;

    /*private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            CollectableManager.instance.ChangeCollection(collectionValue);
        }
    }*/

    public void CollectM()
    {
        InventoryManager.instance.CollectMemory(collectionValue);
    }

    public void CollectJ()
    {
        InventoryManager.instance.CollectJournal(collectionValue);
    }

    public void CollectF()
    {
        InventoryManager.instance.CollectFlare(collectionValue);
    }

    public void CollectB()
    {
        InventoryManager.instance.CollectBottle(collectionValue);
    }
}
